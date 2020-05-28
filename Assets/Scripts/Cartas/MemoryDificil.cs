using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MemoryDificil : MonoBehaviour
{
    public Sprite[] cardFaces;        //se guarda en una lista las partes delanteras de cartas (sprites o imagenes)
    public GameObject cardPrefab;         //Se guarda prefat (parte trasera tarjeta)

    public List<string> deck;
    public List<string> deck2;


    public static string[] suits = new string[] { "R", "Y", "B", "G" };
    public static string[] values = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9"};
   
    //Posiscion de tarjetas
    public GameObject[] bottomPos;      //arrays para ubicar cartas en sitios de pantalla
    public GameObject[] topPos;         //espacios en pantalla donde se pondran cartas

    private MoverCartasDificil moverCartas;

    public static int terminarJuego = 0;
    public static int desbloquearCartas = 0;

    public GameObject highScorePanel;
    public GameObject btnPausa;
    public GameObject txtInstrucciones;
    public GameObject txtInstrucciones2;
    public GameObject btnAtras;
    public GameObject SliderTiempo;
    public GameObject fondoSliderTiempo;
    public GameObject mensajePositivo;
    public GameObject mensajeNegativo;

    public static int numeroAciertos = 0;
    public static int numeroErrores = 0;
    public static int numeroOmisiones = 0;
    public static bool detenerLoop = false;

    // Start is called before the first frame update
    void Start()
    {
        dontDestroy.nivelDificultad = 2;
        print("Dificultad es: "+dontDestroy.nivelDificultad);
        highScorePanel.SetActive(false);
        PlayCards();
        terminarJuego = 0;
        desbloquearCartas = 0;
        numeroAciertos = 0;
        numeroErrores = 0;
        numeroOmisiones = 0;
        detenerLoop = false;

    }
    // Update is called once per frame
    void Update()
    {



        if (MoverCartasDificil.contador == 6)          //Para acceder a una variable static
        {
            if (terminarJuego == 3)
            {
                terminarJuego = 6;
                FindObjectOfType<AudioScriptCartas>().SonidoFinal();
                terminarRondas();
                FindObjectOfType<DBManager>().BtnGuardarPartidaNueva(dontDestroy.cedulaUsuario, "Cartas", "Experto", numeroAciertos,
                                                              numeroErrores, numeroOmisiones, Mathf.RoundToInt(Time.timeSinceLevelLoad));
            }
            else if (terminarJuego < 3)
            {

                if (detenerLoop == false)
                {
                    mensajePositivo.SetActive(true);
                    FindObjectOfType<AudioScriptCartas>().SonidoPositivo();
                    StartCoroutine(nuevaRonda(2));
                    detenerLoop = true;
                }

            }

        }
    }

    public void terminarRondas()
    {
        print("Total de aciertos: " + numeroAciertos);
        print("Total de errores: " + numeroErrores);
        print("Total de omisiones: " + numeroOmisiones);
        print(Mathf.RoundToInt(Time.timeSinceLevelLoad));
        btnPausa.SetActive(false);
        highScorePanel.SetActive(true);
        txtInstrucciones.SetActive(false);
        txtInstrucciones2.SetActive(false);
        SliderTiempo.SetActive(false);
        fondoSliderTiempo.SetActive(false);
        btnAtras.SetActive(false);
        MoverCartasDificil.lockPosicion0 = false;
        MoverCartasDificil.contador++;
    }

    IEnumerator nuevaRonda(float time)
    {
        yield return new WaitForSeconds(time);
        txtInstrucciones.SetActive(true);
        txtInstrucciones2.SetActive(false);


        desbloquearCartas = 0;
        terminarJuego++;

        UpdateSpriteDificil[] cards = FindObjectsOfType<UpdateSpriteDificil>();
        int i = 0;
        foreach (UpdateSpriteDificil card in cards)
        {
            if (i < 6)
            {
                Destroy(card.gameObject);
            }
            i++;
        }
        FindObjectOfType<MemoryDificil>().PlayCards();
        FindObjectOfType<UpdateSpriteDificil>().CrearCartas();
        FindObjectOfType<MoverCartasDificil>().IniciarMovimientos();
        FindObjectOfType<TimeRemaining>().reinicio();
        detenerLoop = false;
        mensajePositivo.SetActive(false);
    }

    public void volverAIntentar()
    {
        FindObjectOfType<AudioScriptCartas>().SonidoNegativo();

        mensajeNegativo.SetActive(true);
        StartCoroutine(eliminarCartasPorError(2));                                             //Reparte Bajara
        StartCoroutine(MemoryDeal2(2));                                             //Reparte Bajara
    }

    IEnumerator eliminarCartasPorError(float time)
    {
        yield return new WaitForSeconds(time);

        UpdateSpriteDificil[] cards = FindObjectsOfType<UpdateSpriteDificil>();
        int i = 0;
        foreach (UpdateSpriteDificil card in cards)
        {
            if (i < 6)
            {
                Destroy(card.gameObject);
            }
            i++;
        }
    }

    public void PlayCards()
    {
        deck = GenerateDeck();                                      //Genera baraja
        Shuffle(deck);                                                //Barajea Baraja

        MemorySort(deck);                                             //Ordena cara con espalda de cartas
        MemoryDeal(deck);                                             //Reparte Bajara
                                                                      //StartCoroutine( MemoryDeal(deck));                        
        deck2 = CopiarDeck(deck);

        Shuffle(deck2);
        StartCoroutine(MemoryDeal3(15));                                             //Reparte Bajara

        StartCoroutine(MemoryDeal2(16));                                             //Reparte Bajara
    }



    //Genera baraja combinando Palos con valores 
    public static List<string> GenerateDeck()
    {
        List<string> newDeck = new List<string>();

        foreach(string s in suits)
        {
            foreach(string v in values)
            {
                newDeck.Add(s + v);
            }
        }

        return newDeck;
    }




    //Metodo para barajar cartas aleatoreamente
    void Shuffle<T>(List<T> list)
    {
        System.Random random = new System.Random();
        int n = list.Count;
        while(n>1)
        {
            int k = random.Next(n);
            n--;
            T temp = list[k];
            list[k] = list[n];
            list[n] = temp;
        }
    }




    //Pone cartas en los espacios que deben ir , elemina cartas que no se van a utilizar llenando solo los espacios de tops[]
    void MemorySort(List<string> deck)
    {
        for (int i = 0; i < 34; i++)
        {
            deck.RemoveAt(deck.Count - 1);     //Remove element (int)
        }
    }





    //Mostrar cartas en pantalla
    void MemoryDeal(List<string> deck)
    {
        int j = 0;
         
        foreach (string card in deck)
        {

                //se hace copia del prefab (parte trasera de carta) y se muestra en pantalla con nombres s+v y posicion de la misma
                GameObject newCard = Instantiate(cardPrefab, new Vector3(topPos[j].transform.position.x, topPos[j].transform.position.y, 
                                                    topPos[j].transform.position.z), Quaternion.identity, topPos[j].transform);

                newCard.name = card;                                        //se le pone el nombre de carta s+v(Diamante + K) al game object (prefab)
                newCard.GetComponent<Selectable>().faceUp = true;           // Hace que toda tarjeta este en faceup = true       
                
      
            j++;

           Destroy(newCard, 15f);

        }
        j = 0;
    }

    //Mostrar parte trasera de cartas
    IEnumerator MemoryDeal3(float time)
    {
        yield return new WaitForSeconds(time);
        int j = 0;

        foreach (string card in deck2)
        {

            //se hace copia del prefab (parte trasera de carta) y se muestra en pantalla con nombres s+v y posicion de la misma
            GameObject newCard = Instantiate(cardPrefab, new Vector3(topPos[j].transform.position.x, topPos[j].transform.position.y,
                                                topPos[j].transform.position.z), Quaternion.identity, topPos[j].transform);

            newCard.name = card;                                        //se le pone el nombre de carta s+v(Diamante + K) al game object (prefab)
            newCard.GetComponent<Selectable>().faceUp = false;           // Hace que toda tarjeta este en faceup = true       

            Destroy(newCard, 1f);

            j++;

        }
        j = 0;
    }


    //Metodo para copiar el deck
    public static List<string> CopiarDeck(List<string> deck)
    {
        List<string> deck2 = new List<string>();

        foreach (string d in deck)
        {
            deck2.Add(d);
        }
        return deck2;
    }


    //Mostrar 4 cartas barajadas
    IEnumerator MemoryDeal2(float time)
    {
        yield return new WaitForSeconds(time);
        int j = 0;

        foreach (string card in deck2)
        {

            //se hace copia del prefab (parte trasera de carta) y se muestra en pantalla con nombres s+v y posicion de la misma
            GameObject newCard = Instantiate(cardPrefab, new Vector3(topPos[j].transform.position.x, topPos[j].transform.position.y,
                                                topPos[j].transform.position.z), Quaternion.identity, topPos[j].transform);

            newCard.name = card;                                        //se le pone el nombre de carta s+v(Diamante + K) al game object (prefab)
            newCard.GetComponent<Selectable>().faceUp = true;           // Hace que toda tarjeta este en faceup = true       


            j++;

        }
        j = 0;
        desbloquearCartas = 1;
        txtInstrucciones.SetActive(false);
        txtInstrucciones2.SetActive(true);
        mensajeNegativo.SetActive(false);
    }


}
