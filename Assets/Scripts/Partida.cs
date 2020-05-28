using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]

public class Partida
{
    public string username_id;
    public string puzzle;
    public string dificultad;
    public int aciertos;
    public int errores;
    public int intruciones;
    public int tiempo;

    public Partida()
    {
    }

    public Partida(string username_id, string puzzle, string dificultad, int aciertos, int errores, int intruciones, int tiempo)
    {
        this.username_id = username_id;
        this.puzzle = puzzle;
        this.dificultad = dificultad;
        this.aciertos = aciertos;
        this.errores = errores;
        this.intruciones = intruciones;
        this.tiempo = tiempo;

    }

}
