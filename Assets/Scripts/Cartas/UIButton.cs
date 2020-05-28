using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButton : MonoBehaviour
{

    public GameObject pauseMenu;
    public GameObject btnPausa;
   


    public void pausarJuego()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        btnPausa.SetActive(false);
        switch (dontDestroy.nivelDificultad)
        {
            case 0:
                MoverCartasFacil.lockedPausa = false;
                break;
            case 1:
                MoverCartas.lockedPausa = false;
                break;
            case 2:
                MoverCartasDificil.lockedPausa = false;
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
                MoverCartasFacil.lockedPausa = true;
                break;
            case 1:
                MoverCartas.lockedPausa = true;
                break;
            case 2:
                MoverCartasDificil.lockedPausa = true;
                break;
        }
    }

    public void reanudarTiempobtnAtras()
    {
        Time.timeScale = 1;
        switch (dontDestroy.nivelDificultad)
        {
            case 0:
                MoverCartasFacil.lockedPausa = true;
                break;
            case 1:
                MoverCartas.lockedPausa = true;
                break;
            case 2:
                MoverCartasDificil.lockedPausa = true;
                break;
        }
    }
    
    public void SiguienteNivel()
    {
        switch(dontDestroy.nivelDificultad)
        {
            case 0:
                SceneManager.LoadScene("Cartas");
                break;
            case 1:
                SceneManager.LoadScene("CartasDificil");
                break;
        }
    }


    public void Reiniciar()
    {
        switch (dontDestroy.nivelDificultad)
        {
            case 0:
                SceneManager.LoadScene("CartasFacil");
                break;
            case 1:
                SceneManager.LoadScene("Cartas");
                break;
            case 2:
                SceneManager.LoadScene("CartasDificil");
                break;
        }
    }


    public void IrAMenuPrincipal()
    {
        SceneManager.LoadScene("Menu");             //Restart de toda la escena
    }

}
