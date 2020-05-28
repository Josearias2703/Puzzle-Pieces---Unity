using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoverCartas : MonoBehaviour
{
    //Arrastrar y soltar

    private Memory memory;
    
    public List<string> deckComparativo;

    private Vector2 initialPosition;

    private Vector2 mousePosition;

    private float deltaX, deltaY;

    public static bool locked;
    public static bool lockedPausa = true;

    public int posicionInicial = 0;

    public GameObject[] bottomPos;      //arrays para ubicar cartas en sitios de pantalla

    public static int contador = 0;

    public static bool lockPosicion0;
    public static bool lockPosicion1;
    public static bool lockPosicion2;
    public static bool lockPosicion3;

    public int posicionActual = 0;



    // Start is called before the first frame update
    void Start()
    {

        int i = 0;
        if(deckComparativo.Count != 0)
        {
            foreach(string s in deckComparativo)
            {
                i++;
            }
        }
        for(int j=0; j<i; j++)
        {
            deckComparativo.RemoveAt(deckComparativo.Count - 1);
        }
        IniciarMovimientos();
        
    }
    
    public void IniciarMovimientos()
    {
        lockPosicion0 = false;
        lockPosicion1 = false;
        lockPosicion2 = false;
        lockPosicion3 = false;
        lockedPausa = true;
        posicionInicial = 0;
        contador = 0;
        posicionActual = 0;
        StartCoroutine(ExecuteAfterTime(0));

        
    }


    //Metodo para obtener orden de primera baraja
    IEnumerator ExecuteAfterTime(float time)
    {
        
            yield return new WaitForSeconds(time);
            memory = FindObjectOfType<Memory>();
            List<string> prueba = new List<string>(memory.deck);   //esto
            foreach (string s in prueba)
            {
                deckComparativo.Add(s);
            }
        
    }




    private void OnMouseDown()
    {
        if (!locked && lockedPausa == true)
        {

            posicionInicial++;
            deltaX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
            deltaY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;
            if (posicionActual == 1)
            {
                lockPosicion0 = false;
                if (this.name == deckComparativo[0])
                {
                    Memory.numeroOmisiones = Memory.numeroOmisiones + 1;
                    contador--;
                }
            }
            if (posicionActual == 2)
            {
                lockPosicion1 = false;
                if (this.name == deckComparativo[1])
                {
                    Memory.numeroOmisiones = Memory.numeroOmisiones + 1;
                    contador--;
                }
            }
            if (posicionActual == 3)
            {
                lockPosicion2 = false;
                if(this.name == deckComparativo[2])
                {
                    Memory.numeroOmisiones = Memory.numeroOmisiones + 1;
                    contador--;
                }
            }
            if (posicionActual == 4)
            {
                lockPosicion3 = false;
                if (this.name == deckComparativo[3])
                {
                    Memory.numeroOmisiones = Memory.numeroOmisiones + 1;
                    contador--;
                }
            }
        }
       
    }
    private void OnMouseDrag()
    {
        if(!locked && lockedPausa == true)
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(mousePosition.x - deltaX, mousePosition.y - deltaY);
        }
    }
    private void OnMouseUp()
    {
        if (lockedPausa == true)
        {
            if (Mathf.Abs(transform.position.x - bottomPos[0].transform.position.x) <= 2f &&
                 Mathf.Abs(transform.position.y - bottomPos[0].transform.position.y) <= 2f &&
                 this.name == deckComparativo[0] && lockPosicion0 == false)
            {
                transform.position = new Vector2(bottomPos[0].transform.position.x, bottomPos[0].transform.position.y);
                lockPosicion0 = true;
                contador++;
                Memory.numeroAciertos = Memory.numeroAciertos + 1;
                posicionActual = 1;
            }
            else if (Mathf.Abs(transform.position.x - bottomPos[0].transform.position.x) <= 2f &&
                 Mathf.Abs(transform.position.y - bottomPos[0].transform.position.y) <= 2f && lockPosicion0 == false)
            {
                transform.position = new Vector2(bottomPos[0].transform.position.x, bottomPos[0].transform.position.y);
                lockPosicion0 = true;
                Memory.numeroErrores = Memory.numeroErrores + 1;
                posicionActual = 1;

            }
            else if (Mathf.Abs(transform.position.x - bottomPos[1].transform.position.x) <= 2f &&
                 Mathf.Abs(transform.position.y - bottomPos[1].transform.position.y) <= 2f &&
                 this.name == deckComparativo[1] && lockPosicion1 == false)
            {
                transform.position = new Vector2(bottomPos[1].transform.position.x, bottomPos[1].transform.position.y);
                lockPosicion1 = true;
                contador++;
                Memory.numeroAciertos = Memory.numeroAciertos + 1;
                posicionActual = 2;

            }
            else if (Mathf.Abs(transform.position.x - bottomPos[1].transform.position.x) <= 2f &&
                Mathf.Abs(transform.position.y - bottomPos[1].transform.position.y) <= 2f && lockPosicion1 == false)
            {
                transform.position = new Vector2(bottomPos[1].transform.position.x, bottomPos[1].transform.position.y);
                lockPosicion1 = true;
                Memory.numeroErrores = Memory.numeroErrores + 1;
                posicionActual = 2;

            }
            else if (Mathf.Abs(transform.position.x - bottomPos[2].transform.position.x) <= 2f &&
                  Mathf.Abs(transform.position.y - bottomPos[2].transform.position.y) <= 2f &&
                  this.name == deckComparativo[2] && lockPosicion2 == false)
            {
                transform.position = new Vector2(bottomPos[2].transform.position.x, bottomPos[2].transform.position.y);
                lockPosicion2 = true;
                contador++;
                Memory.numeroAciertos = Memory.numeroAciertos + 1;
                posicionActual = 3;

            }
            else if (Mathf.Abs(transform.position.x - bottomPos[2].transform.position.x) <= 2f &&
                Mathf.Abs(transform.position.y - bottomPos[2].transform.position.y) <= 2f && lockPosicion2 == false)
            {
                transform.position = new Vector2(bottomPos[2].transform.position.x, bottomPos[2].transform.position.y);
                lockPosicion2 = true;
                Memory.numeroErrores = Memory.numeroErrores + 1;
                posicionActual = 3;

            }
            else if (Mathf.Abs(transform.position.x - bottomPos[3].transform.position.x) <= 2f &&
                      Mathf.Abs(transform.position.y - bottomPos[3].transform.position.y) <= 2f &&
                      this.name == deckComparativo[3] && lockPosicion3 == false)
            {
                transform.position = new Vector2(bottomPos[3].transform.position.x, bottomPos[3].transform.position.y);
                lockPosicion3 = true;
                contador++;
                Memory.numeroAciertos = Memory.numeroAciertos + 1;
                posicionActual = 4;

            }
            else if (Mathf.Abs(transform.position.x - bottomPos[3].transform.position.x) <= 2f &&
                Mathf.Abs(transform.position.y - bottomPos[3].transform.position.y) <= 2f && lockPosicion3 == false)
            {
                transform.position = new Vector2(bottomPos[3].transform.position.x, bottomPos[3].transform.position.y);
                lockPosicion3 = true;
                Memory.numeroErrores = Memory.numeroErrores + 1;
                posicionActual = 4;

            }

            else
            {
                transform.position = new Vector2(initialPosition.x, initialPosition.y);
                posicionActual = 0;

            }
            print(contador);
        }
    }



    // Update is called once per frame
    void Update()
    {
        // Se guarda posicion inicial a donde regresara carta
       if(posicionInicial == 0)
        {
            initialPosition = transform.position;
        }

       if(Memory.desbloquearCartas == 0)
        {
            locked = true;
        }
        else if(Memory.desbloquearCartas == 1)
        {
            locked = false;
        }

        if (lockPosicion0 == true && lockPosicion1 == true && lockPosicion2 == true && lockPosicion3 == true
            && contador != 4)
        {
            Memory.numeroOmisiones = Memory.numeroOmisiones + contador;

            FindObjectOfType<Memory>().volverAIntentar();
            int i = 0;
            if (deckComparativo.Count != 0)
            {
                foreach (string s in deckComparativo)
                {
                    i++;
                }
            }
            for (int j = 0; j < i; j++)
            {
                deckComparativo.RemoveAt(deckComparativo.Count - 1);
            }
            IniciarMovimientos();

        }


        /* if(Input.touchCount>0 && !locked)
         {
             Touch touch = Input.GetTouch(0);
             Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

             switch(touch.phase)
             {
                 case TouchPhase.Began:                  //Recien se toca la pantalla
                     if(GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))      //if(Actually touch the card)
                     {
                        posicionInicial++;
                        deltaX = touchPos.x - transform.position.x;
                         deltaY = touchPos.y - transform.position.y;
                     }
                     break;

                 case TouchPhase.Moved:                  //Mueveel dedo por la pantalla
                     if(GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
                     {
                         transform.position = new Vector2(touchPos.x - deltaX, touchPos.y - deltaY);
                     }
                     break;

                 case TouchPhase.Ended:                  //Se deja de tocar pantalla con dedo
                     if (Mathf.Abs(transform.position.x - bottomPos[0].transform.position.x) <= 2f &&
                         Mathf.Abs(transform.position.y - bottomPos[0].transform.position.y) <= 2f && this.name == deckComparativo[0])
                    {
                        transform.position = new Vector2(bottomPos[0].transform.position.x, bottomPos[0].transform.position.y);
                    }
                    else if(Mathf.Abs(transform.position.x - bottomPos[1].transform.position.x) <= 2f &&
                        Mathf.Abs(transform.position.y - bottomPos[1].transform.position.y) <= 2f && this.name == deckComparativo[1])
                    {
                        transform.position = new Vector2(bottomPos[1].transform.position.x, bottomPos[1].transform.position.y);
                    }
                    else if (Mathf.Abs(transform.position.x - bottomPos[2].transform.position.x) <= 2f &&
                         Mathf.Abs(transform.position.y - bottomPos[2].transform.position.y) <= 2f && this.name == deckComparativo[2])
                    {
                        transform.position = new Vector2(bottomPos[2].transform.position.x, bottomPos[2].transform.position.y);
                    }
                    else if (Mathf.Abs(transform.position.x - bottomPos[3].transform.position.x) <= 2f &&
                             Mathf.Abs(transform.position.y - bottomPos[3].transform.position.y) <= 2f && this.name == deckComparativo[3])
                    {
                        transform.position = new Vector2(bottomPos[3].transform.position.x, bottomPos[3].transform.position.y);
                    }
                    else
                    {
                        transform.position = new Vector2(initialPosition.x, initialPosition.y);
                    }
                     break;
             }
         }*/
    }
}
