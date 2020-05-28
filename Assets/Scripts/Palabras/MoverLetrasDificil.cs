using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoverLetrasDificil : MonoBehaviour
{

    private PalabrasDificil palabras;
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
    public static bool lockPosicion5;
    public static bool lockPosicion6;
    public static bool lockPosicion7;
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
        lockPosicion5 = false;
        lockPosicion6 = false;
        lockPosicion7 = false;
        posicionInicial = 0;
        locked = true;
        contador = 0;
        posicionActual = 0;
        obtenerPalabraRespuesta();
    }

    
    void obtenerPalabraRespuesta()
    {
        switch(PalabrasDificil.ronda)
        {
            case 0:
                palabraComparativa = PalabrasDificil.primeraPalabra;
                break;
            case 1:
                palabraComparativa = PalabrasDificil.segundaPalabra;
                break;
            case 2:
                palabraComparativa = PalabrasDificil.terceraPalabra;
                break;
            case 3:
                palabraComparativa = PalabrasDificil.cuartaPalabra;
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
                    PalabrasDificil.numeroOmisiones = PalabrasDificil.numeroOmisiones + 1;
                    contador--;
                }
            }
            if (posicionActual == 2)
            {
                lockPosicion1 = false;
                if (this.name == palabraComparativa.Substring(1, 1))
                {
                    PalabrasDificil.numeroOmisiones = PalabrasDificil.numeroOmisiones + 1;
                    contador--;
                }
            }
            if (posicionActual == 3)
            {
                lockPosicion2 = false;
                if (this.name == palabraComparativa.Substring(2, 1))
                {
                    PalabrasDificil.numeroOmisiones = PalabrasDificil.numeroOmisiones + 1;
                    contador--;
                }
            }
            if (posicionActual == 4)
            {
                lockPosicion3 = false;
                if (this.name == palabraComparativa.Substring(3, 1))
                {
                    PalabrasDificil.numeroOmisiones = PalabrasDificil.numeroOmisiones + 1;
                    contador--;
                }
            }
            if (posicionActual == 5)
            {
                lockPosicion4 = false;
                if (this.name == palabraComparativa.Substring(4, 1))
                {
                    PalabrasDificil.numeroOmisiones = PalabrasDificil.numeroOmisiones + 1;
                    contador--;
                }
            }
            if (posicionActual == 6)
            {
                lockPosicion5 = false;
                if (this.name == palabraComparativa.Substring(5, 1))
                {
                    PalabrasDificil.numeroOmisiones = PalabrasDificil.numeroOmisiones + 1;
                    contador--;
                }
            }
            if (posicionActual == 7)
            {
                lockPosicion6 = false;
                if (this.name == palabraComparativa.Substring(6, 1))
                {
                    PalabrasDificil.numeroOmisiones = PalabrasDificil.numeroOmisiones + 1;
                    contador--;
                }
            }
            if (posicionActual == 8)
            {
                lockPosicion7 = false;
                if (this.name == palabraComparativa.Substring(7, 1))
                {
                    PalabrasDificil.numeroOmisiones = PalabrasDificil.numeroOmisiones + 1;
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
                PalabrasDificil.numeroAciertos = PalabrasDificil.numeroAciertos + 1;
            }
            else if (Mathf.Abs(transform.position.x - bottomPos[0].transform.position.x) <= 1f &&
                 Mathf.Abs(transform.position.y - bottomPos[0].transform.position.y) <= 1f && lockPosicion0 == false)
            {
                transform.position = new Vector2(bottomPos[0].transform.position.x, bottomPos[0].transform.position.y);
                lockPosicion0 = true;
                posicionActual = 1;
                PalabrasDificil.numeroErrores = PalabrasDificil.numeroErrores + 1;


            }
            else if (Mathf.Abs(transform.position.x - bottomPos[1].transform.position.x) <= 1f &&
                 Mathf.Abs(transform.position.y - bottomPos[1].transform.position.y) <= 1f &&
                 this.name == palabraComparativa.Substring(1, 1) && lockPosicion1 == false)
            {
                transform.position = new Vector2(bottomPos[1].transform.position.x, bottomPos[1].transform.position.y);
                lockPosicion1 = true;
                contador++;
                posicionActual = 2;
                PalabrasDificil.numeroAciertos = PalabrasDificil.numeroAciertos + 1;

            }
            else if (Mathf.Abs(transform.position.x - bottomPos[1].transform.position.x) <= 1f &&
                Mathf.Abs(transform.position.y - bottomPos[1].transform.position.y) <= 1f && lockPosicion1 == false)
            {
                transform.position = new Vector2(bottomPos[1].transform.position.x, bottomPos[1].transform.position.y);
                lockPosicion1 = true;
                posicionActual = 2;
                PalabrasDificil.numeroErrores = PalabrasDificil.numeroErrores + 1;

            }
            else if (Mathf.Abs(transform.position.x - bottomPos[2].transform.position.x) <= 1f &&
                  Mathf.Abs(transform.position.y - bottomPos[2].transform.position.y) <= 1f &&
                  this.name == palabraComparativa.Substring(2, 1) && lockPosicion2 == false)
            {
                transform.position = new Vector2(bottomPos[2].transform.position.x, bottomPos[2].transform.position.y);
                lockPosicion2 = true;
                contador++;
                posicionActual = 3;
                PalabrasDificil.numeroAciertos = PalabrasDificil.numeroAciertos + 1;

            }
            else if (Mathf.Abs(transform.position.x - bottomPos[2].transform.position.x) <= 1f &&
                Mathf.Abs(transform.position.y - bottomPos[2].transform.position.y) <= 1f && lockPosicion2 == false)
            {
                transform.position = new Vector2(bottomPos[2].transform.position.x, bottomPos[2].transform.position.y);
                lockPosicion2 = true;
                posicionActual = 3;
                PalabrasDificil.numeroErrores = PalabrasDificil.numeroErrores + 1;

            }
            else if (Mathf.Abs(transform.position.x - bottomPos[3].transform.position.x) <= 1f &&
                      Mathf.Abs(transform.position.y - bottomPos[3].transform.position.y) <= 1f &&
                      this.name == palabraComparativa.Substring(3, 1) && lockPosicion3 == false)
            {
                transform.position = new Vector2(bottomPos[3].transform.position.x, bottomPos[3].transform.position.y);
                lockPosicion3 = true;
                contador++;
                posicionActual = 4;
                PalabrasDificil.numeroAciertos = PalabrasDificil.numeroAciertos + 1;

            }
            else if (Mathf.Abs(transform.position.x - bottomPos[3].transform.position.x) <= 1f &&
                Mathf.Abs(transform.position.y - bottomPos[3].transform.position.y) <= 1f && lockPosicion3 == false)
            {
                transform.position = new Vector2(bottomPos[3].transform.position.x, bottomPos[3].transform.position.y);
                lockPosicion3 = true;
                posicionActual = 4;
                PalabrasDificil.numeroErrores = PalabrasDificil.numeroErrores + 1;

            }
            else if (Mathf.Abs(transform.position.x - bottomPos[4].transform.position.x) <= 1f &&
                      Mathf.Abs(transform.position.y - bottomPos[4].transform.position.y) <= 1f &&
                      this.name == palabraComparativa.Substring(4, 1) && lockPosicion4 == false)
            {
                transform.position = new Vector2(bottomPos[4].transform.position.x, bottomPos[4].transform.position.y);
                lockPosicion4 = true;
                contador++;
                posicionActual = 5;
                PalabrasDificil.numeroAciertos = PalabrasDificil.numeroAciertos + 1;

            }
            else if (Mathf.Abs(transform.position.x - bottomPos[4].transform.position.x) <= 1f &&
                Mathf.Abs(transform.position.y - bottomPos[4].transform.position.y) <= 1f && lockPosicion4 == false)
            {
                transform.position = new Vector2(bottomPos[4].transform.position.x, bottomPos[4].transform.position.y);
                lockPosicion4 = true;
                posicionActual = 5;
                PalabrasDificil.numeroErrores = PalabrasDificil.numeroErrores + 1;

            }
            else if (Mathf.Abs(transform.position.x - bottomPos[5].transform.position.x) <= 1f &&
                    Mathf.Abs(transform.position.y - bottomPos[5].transform.position.y) <= 1f &&
                    this.name == palabraComparativa.Substring(5, 1) && lockPosicion5 == false)
            {
                transform.position = new Vector2(bottomPos[5].transform.position.x, bottomPos[5].transform.position.y);
                lockPosicion5 = true;
                contador++;
                posicionActual = 6;
                PalabrasDificil.numeroAciertos = PalabrasDificil.numeroAciertos + 1;

            }
            else if (Mathf.Abs(transform.position.x - bottomPos[5].transform.position.x) <= 1f &&
                Mathf.Abs(transform.position.y - bottomPos[5].transform.position.y) <= 1f && lockPosicion5 == false)
            {
                transform.position = new Vector2(bottomPos[5].transform.position.x, bottomPos[5].transform.position.y);
                lockPosicion5 = true;
                posicionActual = 6;
                PalabrasDificil.numeroErrores = PalabrasDificil.numeroErrores + 1;

            }
            else if (Mathf.Abs(transform.position.x - bottomPos[6].transform.position.x) <= 1f &&
                    Mathf.Abs(transform.position.y - bottomPos[6].transform.position.y) <= 1f &&
                    this.name == palabraComparativa.Substring(6, 1) && lockPosicion6 == false)
            {
                transform.position = new Vector2(bottomPos[6].transform.position.x, bottomPos[6].transform.position.y);
                lockPosicion6 = true;
                contador++;
                posicionActual = 7;
                PalabrasDificil.numeroAciertos = PalabrasDificil.numeroAciertos + 1;

            }
            else if (Mathf.Abs(transform.position.x - bottomPos[6].transform.position.x) <= 1f &&
                Mathf.Abs(transform.position.y - bottomPos[6].transform.position.y) <= 1f && lockPosicion6 == false)
            {
                transform.position = new Vector2(bottomPos[6].transform.position.x, bottomPos[6].transform.position.y);
                lockPosicion6 = true;
                posicionActual = 7;
                PalabrasDificil.numeroErrores = PalabrasDificil.numeroErrores + 1;

            }
            else if (Mathf.Abs(transform.position.x - bottomPos[7].transform.position.x) <= 1f &&
                    Mathf.Abs(transform.position.y - bottomPos[7].transform.position.y) <= 1f &&
                    this.name == palabraComparativa.Substring(7, 1) && lockPosicion7 == false)
            {
                transform.position = new Vector2(bottomPos[7].transform.position.x, bottomPos[7].transform.position.y);
                lockPosicion7 = true;
                contador++;
                posicionActual = 8;
                PalabrasDificil.numeroAciertos = PalabrasDificil.numeroAciertos + 1;

            }
            else if (Mathf.Abs(transform.position.x - bottomPos[7].transform.position.x) <= 1f &&
                Mathf.Abs(transform.position.y - bottomPos[7].transform.position.y) <= 1f && lockPosicion7 == false)
            {
                transform.position = new Vector2(bottomPos[7].transform.position.x, bottomPos[7].transform.position.y);
                lockPosicion7 = true;
                posicionActual = 8;
                PalabrasDificil.numeroErrores = PalabrasDificil.numeroErrores + 1;

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


        if (lockPosicion0 == true && lockPosicion1 == true && lockPosicion2 == true && lockPosicion3 == true && lockPosicion4 == true && lockPosicion5 == true && lockPosicion6 == true && lockPosicion7 == true
            && contador != 8)
        {

            FindObjectOfType<PalabrasDificil>().volerAIntentar();
            IniciarMovimientos();

        }
    }
}
