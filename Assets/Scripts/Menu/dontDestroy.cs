using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dontDestroy : MonoBehaviour

{
    public static int introPrimeraVez = 0;
    public static int nivelDificultad = 0;
    public static string cedulaUsuario;
    public static string userName;
    public static float volumenJuego = 0.3f;


   
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
    

    public void dificultadInicial()
    {
        nivelDificultad = 0;
    }
    public void dificultadMedio()
    {
        nivelDificultad = 1;
    }
    public void dificultadExperto()
    {
        nivelDificultad = 2;
    }
}
