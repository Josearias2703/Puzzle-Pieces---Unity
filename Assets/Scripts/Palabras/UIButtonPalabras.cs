using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtonPalabras : MonoBehaviour
{

    public GameObject highScorePanle;
    public GameObject pauseMenu;
    public GameObject btnPausa;
    public GameObject txtInstruccion;
    public GameObject btnAudio;


    public void pausarJuego()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        btnPausa.SetActive(false);
        switch (dontDestroy.nivelDificultad)
        {
            case 0:
                MoverLetras.locked = false;
                break;
            case 1:
                MoverLetrasNormal.locked = false;
                break;
            case 2:
                MoverLetrasDificil.locked = false;
                break;

        }
       
    }

    public void resuminJuego()
    {
       
        
        pauseMenu.SetActive(false);
        btnPausa.SetActive(true);
        Time.timeScale = 1;
        switch (dontDestroy.nivelDificultad)
        {
            case 0:
                MoverLetras.locked = true;
                break;
            case 1:
                MoverLetrasNormal.locked = true;
                break;
            case 2:
                MoverLetrasDificil.locked = true;
                break;

        }
    }


    public void ReiniciarPalabrasFacil()
    {
        switch(dontDestroy.nivelDificultad)
        {
            case 0:
                SceneManager.LoadScene("Palabras");
                Time.timeScale = 1;
                break;
            case 1:
                SceneManager.LoadScene("PalabrasNormal");
                Time.timeScale = 1;
                break;
            case 2:
                SceneManager.LoadScene("PalabrasDificil");
                Time.timeScale = 1;
                break;

        }
        
    }

    public void IrAMenuPrincipal()
    {
        SceneManager.LoadScene("Menu");             //Restart de toda la escena
    }

    public void reanudarTiempobtnAtras()
    {
        Time.timeScale = 1;
        switch (dontDestroy.nivelDificultad)
        {
            case 0:
                MoverLetras.locked = true;
                break;
            case 1:
                MoverLetrasNormal.locked = true;
                break;
            case 2:
                MoverLetrasDificil.locked = true;
                break;

        }
    }

    public void SiguienteNivel()
    {
        switch (dontDestroy.nivelDificultad)
        {
            case 0:
                SceneManager.LoadScene("Palabrasnormal");
                Time.timeScale = 1;
                break;
      
            case 1:
                SceneManager.LoadScene("PalabrasDificil");
                Time.timeScale = 1;
                break;

        }
    }
}
