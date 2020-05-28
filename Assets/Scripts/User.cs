using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]

public class User
{
    public string username;
    public string password;
    public string nombreReal;
    public string cedula;
    public string genero;
    public int edad;

    public User()
    {

    }

    public User(string username,  string password, string nombreReal, string cedula, string genero, int edad)
    {
        this.username = username;
        this.password = password;
        this.nombreReal = nombreReal;
        this.cedula = cedula;
        this.genero = genero;
        this.edad = edad;

    }
}
