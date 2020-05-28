using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoverLetras : MonoBehaviour
{

    private Palabras palabras;
    private Vector2 initialPosition;
    private Vector2 mousePosition;
    private float deltaX, deltaY;
    public int posicionInicial = 0;
    public GameObject[] bottomPos;
    public static int contador = 0;
    public static bool lockPosicion0;
    public static bool lockPosicion1;
    public static bool lockPosicion2;
    public static bool lockPosicion3;
    public static bool lockPosicion4;
    public int posicionActual = 0;
    public static string palabraComparativa;
    public static bool locked = true;


    // Start is called before the first frame update
    void Start()
    {
        IniciarMovimientos();
    }

    public void IniciarMovimientos()
    {
        lockPosicion0 = false;
        lockPosicion1 = false;
        lockPosicion2 = false;
        lockPosicion3 = false;
        lockPosicion4 = false;
        locked = true;
        posicionInicial = 0;
        contador = 0;
        posicionActual = 0;
        obtenerPalabraRespuesta();
    }

    
    void obtenerPalabraRespuesta()
    {
        switch(Palabras.ronda)
        {
            case 0:
                palabraComparativa = Palabras.primeraPalabra;
                break;
            case 1:
                palabraComparativa = Palabras.segundaPalabra;
                break;
            case 2:
                palabraComparativa = Palabras.terceraPalabra;
                break;
            case 3:
                palabraComparativa = Palabras.cuartaPalabra;
                break;
        }
    }

    private void OnMouseDown()
    {
        if (contador>=0 && locked == true)
        {

            posicionInicial++;
            deltaX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
            deltaY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;
            if (posicionActual == 1)
            {
                lockPosicion0 = false;
                if (this.name == palabraComparativa.Substring(0 , 1))
                {
                    Palabras.numeroOmisiones = Palabras.numeroOmisiones + 1;
                    contador--;
                }
            }
            if (posicionActual == 2)
            {
                lockPosicion1 = false;
                if (this.name == palabraComparativa.Substring(1, 1))
                {
                    Palabras.numeroOmisiones = Palabras.numeroOmisiones + 1;
                    contador--;
                }
            }
            if (posicionActual == 3)
            {
                lockPosicion2 = false;
                if (this.name == palabraComparativa.Substring(2, 1))
                {
                    Palabras.numeroOmisiones = Palabras.numeroOmisiones + 1;
                    contador--;
                }
            }
            if (posicionActual == 4)
            {
                lockPosicion3 = false;
                if (this.name == palabraComparativa.Substring(3, 1))
                {
                    Palabras.numeroOmisiones = Palabras.numeroOmisiones + 1;
                    contador--;
                }
            }
            if (posicionActual == 5)
            {
                lockPosicion4 = false;
                if (this.name == palabraComparativa.Substring(4, 1))
                {
                    Palabras.numeroOmisiones = Palabras.numeroOmisiones + 1;
                    contador--;
                }
            }
        }
        

    }
    private void OnMouseDrag()
    {
        if (contador>=0 && locked == true)
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(mousePosition.x - deltaX, mousePosition.y - deltaY);
        }
    }
    private void OnMouseUp()
    {
        if (locked == true)
        {
            if (Mathf.Abs(transform.position.x - bottomPos[0].transform.position.x) <= 1f &&
             Mathf.Abs(transform.position.y - bottomPos[0].transform.position.y) <= 1f &&
             this.name == palabraComparativa.Substring(0, 1) && lockPosicion0 == false)
            {
                transform.position = new Vector2(bottomPos[0].transform.position.x, bottomPos[0].transform.position.y);
                lockPosicion0 = true;
                contador++;
                posicionActual = 1;
                Palabras.numeroAciertos = Palabras.numeroAciertos + 1;
            }
            else if (Mathf.Abs(transform.position.x - bottomPos[0].transform.position.x) <= 1f &&
                 Mathf.Abs(transform.position.y - bottomPos[0].transform.position.y) <= 1f && lockPosicion0 == false)
            {
                transform.position = new Vector2(bottomPos[0].transform.position.x, bottomPos[0].transform.position.y);
                lockPosicion0 = true;
                posicionActual = 1;
                Palabras.numeroErrores = Palabras.numeroErrores + 1;


            }
            else if (Mathf.Abs(transform.position.x - bottomPos[1].transform.position.x) <= 1f &&
                 Mathf.Abs(transform.position.y - bottomPos[1].transform.position.y) <= 1f &&
                 this.name == palabraComparativa.Substring(1, 1) && lockPosicion1 == false)
            {
                transform.position = new Vector2(bottomPos[1].transform.position.x, bottomPos[1].transform.position.y);
                lockPosicion1 = true;
                contador++;
                posicionActual = 2;
                Palabras.numeroAciertos = Palabras.numeroAciertos + 1;

            }
            else if (Mathf.Abs(transform.position.x - bottomPos[1].transform.position.x) <= 1f &&
                Mathf.Abs(transform.position.y - bottomPos[1].transform.position.y) <= 1f && lockPosicion1 == false)
            {
                transform.position = new Vector2(bottomPos[1].transform.position.x, bottomPos[1].transform.position.y);
                lockPosicion1 = true;
                posicionActual = 2;
                Palabras.numeroErrores = Palabras.numeroErrores + 1;

            }
            else if (Mathf.Abs(transform.position.x - bottomPos[2].transform.position.x) <= 1f &&
                  Mathf.Abs(transform.position.y - bottomPos[2].transform.position.y) <= 1f &&
                  this.name == palabraComparativa.Substring(2, 1) && lockPosicion2 == false)
            {
                transform.position = new Vector2(bottomPos[2].transform.position.x, bottomPos[2].transform.position.y);
                lockPosicion2 = true;
                contador++;
                posicionActual = 3;
                Palabras.numeroAciertos = Palabras.numeroAciertos + 1;

            }
            else if (Mathf.Abs(transform.position.x - bottomPos[2].transform.position.x) <= 1f &&
                Mathf.Abs(transform.position.y - bottomPos[2].transform.position.y) <= 1f && lockPosicion2 == false)
            {
                transform.position = new Vector2(bottomPos[2].transform.position.x, bottomPos[2].transform.position.y);
                lockPosicion2 = true;
                posicionActual = 3;
                Palabras.numeroErrores = Palabras.numeroErrores + 1;

            }
            else if (Mathf.Abs(transform.position.x - bottomPos[3].transform.position.x) <= 1f &&
                      Mathf.Abs(transform.position.y - bottomPos[3].transform.position.y) <= 1f &&
                      this.name == palabraComparativa.Substring(3, 1) && lockPosicion3 == false)
            {
                transform.position = new Vector2(bottomPos[3].transform.position.x, bottomPos[3].transform.position.y);
                lockPosicion3 = true;
                contador++;
                posicionActual = 4;
                Palabras.numeroAciertos = Palabras.numeroAciertos + 1;

            }
            else if (Mathf.Abs(transform.position.x - bottomPos[3].transform.position.x) <= 1f &&
                Mathf.Abs(transform.position.y - bottomPos[3].transform.position.y) <= 1f && lockPosicion3 == false)
            {
                transform.position = new Vector2(bottomPos[3].transform.position.x, bottomPos[3].transform.position.y);
                lockPosicion3 = true;
                posicionActual = 4;
                Palabras.numeroErrores = Palabras.numeroErrores + 1;

            }
            else if (Mathf.Abs(transform.position.x - bottomPos[4].transform.position.x) <= 1f &&
                      Mathf.Abs(transform.position.y - bottomPos[4].transform.position.y) <= 1f &&
                      this.name == palabraComparativa.Substring(4, 1) && lockPosicion4 == false)
            {
                transform.position = new Vector2(bottomPos[4].transform.position.x, bottomPos[4].transform.position.y);
                lockPosicion4 = true;
                contador++;
                posicionActual = 5;
                Palabras.numeroAciertos = Palabras.numeroAciertos + 1;

            }
            else if (Mathf.Abs(transform.position.x - bottomPos[4].transform.position.x) <= 1f &&
                Mathf.Abs(transform.position.y - bottomPos[4].transform.position.y) <= 1f && lockPosicion4 == false)
            {
                transform.position = new Vector2(bottomPos[4].transform.position.x, bottomPos[4].transform.position.y);
                lockPosicion4 = true;
                posicionActual = 5;
                Palabras.numeroErrores = Palabras.numeroErrores + 1;

            }
            else
            {
                transform.position = new Vector2(initialPosition.x, initialPosition.y);
                posicionActual = 0;

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (posicionInicial == 0)
        {
            initialPosition = transform.position;
        }


        if (lockPosicion0 == true && lockPosicion1 == true && lockPosicion2 == true && lockPosicion3 == true && lockPosicion4 == true
            && contador != 5)
        {

            FindObjectOfType<Palabras>().volerAIntentar();
            IniciarMovimientos();

        }
    }
}
