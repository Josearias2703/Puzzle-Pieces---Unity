using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class PalabrasNormal : MonoBehaviour
{
    public Sprite[] letterFaces;
    public Sprite[] imageFaces;

    public GameObject letterPrefab;
    public GameObject imagePrefab;

    public static string[] letters = new string[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z","á","é","í","ó","ú" };
    public static string[] images = new string[] { "dienteb", "sandíab", "antenad", "pincelq", "anilloy", "lentesi", "puenteq", "puertaq", "sillóny", "violínb" };

    public List<string> alfabeto;
    public List<string> imagenes;

    public GameObject[] bottomPos;
    public GameObject[] centerPos;
    public GameObject[] topPos;

    public static string primeraPalabra = null;
    public static string segundaPalabra = null;
    public static string terceraPalabra = null;
    public static string cuartaPalabra = null;

    public static int ronda = 0;

    public GameObject highScorePanel;
    public GameObject btnPausa;
    public GameObject txtInstrucciones;
    public GameObject btnAudio;
    public GameObject btnAtras;
    public GameObject mensajePositivo;
    public GameObject mensajeNegativo;


    public static int numeroAciertos = 0;
    public static int numeroErrores = 0;
    public static int numeroOmisiones = 0;

    public static bool detenerLoop = false;


    // Start is called before the first frame update
    void Start()
    {
        dontDestroy.nivelDificultad = 1;
        highScorePanel.SetActive(false);
        ronda = 0;
        numeroAciertos = 0;
        numeroErrores = 0;
        numeroOmisiones = 0;
        txtInstrucciones.SetActive(true);
        detenerLoop = false;
        EmpezarJuego();
    }

    // Update is called once per frame
    void Update()
    {
        if (MoverLetrasNormal.contador == 6)         
        {
            if (ronda == 4)
            {
                terminarJuego();
                ronda++;
            }
            else if (ronda < 4)
            {
                if (detenerLoop == false)
                {
                    mensajePositivo.SetActive(true);
                    StartCoroutine(nuevaRonda(2));
                    detenerLoop = true;
                  //  ronda++;
                }
            }    
        }

    }

    public void terminarJuego()
    {
        print("Total de aciertos: " + numeroAciertos);
        print("Total de errores: " + numeroErrores);
        print("Total de omisiones: " + numeroOmisiones);
        print(Mathf.RoundToInt(Time.timeSinceLevelLoad));
        txtInstrucciones.SetActive(false);
        btnPausa.SetActive(false);
        btnAtras.SetActive(false);
        btnAudio.SetActive(false);
        highScorePanel.SetActive(true);
        FindObjectOfType<AudioScript>().SonidoFinal();
        FindObjectOfType<DBManager>().BtnGuardarPartidaNueva(dontDestroy.cedulaUsuario, "Palabras", "Medio", numeroAciertos,
                                                              numeroErrores, numeroOmisiones, Mathf.RoundToInt(Time.timeSinceLevelLoad));
    }

    IEnumerator nuevaRonda(float time)
    {
        ronda++;
        if (ronda < 4)
        {
            FindObjectOfType<AudioScript>().SonidoPositivo();

            yield return new WaitForSeconds(time);
            UpdateLetraNormal[] letras = FindObjectsOfType<UpdateLetraNormal>();
            int i = 0;
            foreach (UpdateLetraNormal card in letras)
            {
                if (i < 18)
                {
                    Destroy(card.gameObject);
                }
                i++;
            }
            UpdateImagenNormal[] imagenes = FindObjectsOfType<UpdateImagenNormal>();
            int j = 0;
            foreach (UpdateImagenNormal card in imagenes)
            {
                if (j < 1)
                {
                    Destroy(card.gameObject);
                }
                j++;
            }
            FindObjectOfType<PalabrasNormal>().EmpezarJuego();
            FindObjectOfType<UpdateLetraNormal>().CrearLetras();
            FindObjectOfType<UpdateImagenNormal>().CrearImagen();
            FindObjectOfType<MoverLetrasNormal>().IniciarMovimientos();
            detenerLoop = false;
        }
        mensajePositivo.SetActive(false);

    }


    public void volerAIntentar()
    {
        FindObjectOfType<AudioScript>().SonidoNegativo();
        mensajeNegativo.SetActive(true);
        StartCoroutine(eliminarLetrasPorError(2));                                             //Reparte Bajara
    }

    IEnumerator eliminarLetrasPorError(float time)
    {
        yield return new WaitForSeconds(time);

        UpdateLetraNormal[] letras = FindObjectsOfType<UpdateLetraNormal>();
        int i = 0;
        foreach (UpdateLetraNormal card in letras)
        {
            if (i < 18)
            {
                Destroy(card.gameObject);
            }
            i++;
        }
        UpdateImagenNormal[] imagenes = FindObjectsOfType<UpdateImagenNormal>();
        int j = 0;
        foreach (UpdateImagenNormal card in imagenes)
        {
            if (j < 1)
            {
                Destroy(card.gameObject);
            }
            j++;
        }
        LettersDeal(alfabeto);
        mensajeNegativo.SetActive(false);

    }



    public void EmpezarJuego()
    {
        alfabeto = GenerateAlphabet();
        imagenes = GenerateImages();
        Shuffle(alfabeto);
        Shuffle(imagenes);
        LettersEliminate(alfabeto);
        ImagesSort(imagenes);
        EstablecerPalabras(imagenes);
        AgregarLetrasPalabraImagen(alfabeto);
        Shuffle(alfabeto);
        LettersDeal(alfabeto);

    }

    public static List<string> GenerateAlphabet()
    {
        List<string> newDeck = new List<string>();
        
            foreach (string v in letters)
            {
                newDeck.Add(v);
            }
        return newDeck;
    }

    public static List<string> GenerateImages()
    {
        List<string> newDeck = new List<string>();

        foreach (string v in images)
        {
            newDeck.Add(v);
        }
        return newDeck;
    }

    //Metodo para barajar cartas aleatoreamente
    void Shuffle<T>(List<T> list)
    {
        System.Random random = new System.Random();
        int n = list.Count;
        while (n > 1)
        {
            int k = random.Next(n);
            n--;
            T temp = list[k];
            list[k] = list[n];
            list[n] = temp;
        }
    }

    //Eliminar letras que no se pondran en pantalla
    void LettersEliminate(List<string> deck)                  //cambiar en dificultad
    {
        for (int i = 0; i < 20; i++)
        {
            deck.RemoveAt(deck.Count - 1);   
        }
    }

    //Eliminar dibujos que no se pondran en pantalla
    void ImagesSort(List<string> deck)
    {
        for (int i = 0; i < 6; i++)
        {
            deck.RemoveAt(deck.Count - 1);   
        }
    }


    void EstablecerPalabras(List<string> lista)
    {
        if (ronda == 0)
        {
            primeraPalabra = lista[0];
            segundaPalabra = lista[1];
            terceraPalabra = lista[2];
            cuartaPalabra = lista[3];
        }

    }



    void AgregarLetrasPalabraImagen(List<string> deck)
    {
        switch(ronda)
        {
            case 0:
                for (int i = 0; i < 7; i++)                                  //cambiar en dificultad
                {
                    deck.Add(primeraPalabra.Substring(i, 1));
                }
                break;
            case 1:
                for (int i = 0; i < 7; i++)                                  //cambiar en dificultad
                {
                    deck.Add(segundaPalabra.Substring(i, 1));
                }
                break;
            case 2:
                for (int i = 0; i < 7; i++)                                  //cambiar en dificultad
                {
                    deck.Add(terceraPalabra.Substring(i, 1));
                }
                break;
            case 3:
                for (int i = 0; i < 7; i++)                                  //cambiar en dificultad
                {
                    deck.Add(cuartaPalabra.Substring(i, 1));
                }
                break;

        }
 
    }



    //Mostrar cartas en pantalla
    void LettersDeal(List<string> deck)
    {
        int j = 0;

        foreach (string card in deck)
        {
            if (j < 18)
            {
                //se hace copia del prefab (parte trasera de carta) y se muestra en pantalla con nombres s+v y posicion de la misma
                GameObject newLetter = Instantiate(letterPrefab, new Vector3(topPos[j].transform.position.x, topPos[j].transform.position.y,
                                                    topPos[j].transform.position.z), Quaternion.identity, topPos[j].transform);

                newLetter.name = card;                                        //se le pone el nombre de carta s+v(Diamante + K) al game object (prefab)
                                                                              // newLetter.GetComponent<Selectable>().faceUp = true;           // Hace que toda tarjeta este en faceup = true       
            }
            j++;
        }
        switch (ronda)
        {
            case 0:               
                GameObject newImage = Instantiate(imagePrefab, new Vector3(centerPos[0].transform.position.x, centerPos[0].transform.position.y,
                                                    centerPos[0].transform.position.z), Quaternion.identity, centerPos[0].transform);
                newImage.name = primeraPalabra;            
                break;
            case 1:
                GameObject newImage2 = Instantiate(imagePrefab, new Vector3(centerPos[0].transform.position.x, centerPos[0].transform.position.y,
                                                    centerPos[0].transform.position.z), Quaternion.identity, centerPos[0].transform);
                newImage2.name = segundaPalabra;
                break;
            case 2:
                GameObject newImage3 = Instantiate(imagePrefab, new Vector3(centerPos[0].transform.position.x, centerPos[0].transform.position.y,
                                                    centerPos[0].transform.position.z), Quaternion.identity, centerPos[0].transform);
                newImage3.name = terceraPalabra;
                break;
            case 3:
                GameObject newImage4 = Instantiate(imagePrefab, new Vector3(centerPos[0].transform.position.x, centerPos[0].transform.position.y,
                                                    centerPos[0].transform.position.z), Quaternion.identity, centerPos[0].transform);
                newImage4.name = cuartaPalabra;
                break;
        }
        j = 0;
        FindObjectOfType<AudioScript>().hacerSonido();

    }
}
