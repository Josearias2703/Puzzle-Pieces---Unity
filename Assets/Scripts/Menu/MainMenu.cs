using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;


public class MainMenu : MonoBehaviour
{

    public GameObject panelIntro;
    public GameObject panelMenuPrincipal;
    public GameObject panelLogIn;
    private AudioSource audioSource;
    //public AudioMixer audioMixer;

    private float musicVolume = 0.3f;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        EmpezarJuego();
  
    }

    public void EmpezarJuego()
    {
        if (dontDestroy.introPrimeraVez == 0)
        {
            StartCoroutine(Intro(5));
        }
        else if(dontDestroy.introPrimeraVez == 1)
        {
            panelIntro.SetActive(false);
            panelLogIn.SetActive(false);
            panelMenuPrincipal.SetActive(true);
        }

    }

    //Intro de juego. despues de x tiempo se quita el intro
    IEnumerator Intro(float time)
    {
        yield return new WaitForSeconds(time);
        panelIntro.SetActive(false);
        panelLogIn.SetActive(true);

    }

        public void botonSalir()
    {
        Debug.Log("SALIR!");
        Application.Quit();
    }

    //Comienza la escena del juego, dependiendo dificultad
    public void CompletarPalabras()
    {
        
        switch(dontDestroy.nivelDificultad)
        {
            case 0:
                SceneManager.LoadScene("Palabras");
                break;
            case 1:
                SceneManager.LoadScene("PalabrasNormal");
                break;
            case 2:
                SceneManager.LoadScene("PalabrasDificil");
                break;
        }
        dontDestroy.introPrimeraVez = 1;
    }

    //Comienza la escena del juego, dependiendo dificultad
    public void OrdenarCartas()
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
        dontDestroy.introPrimeraVez = 1;
    }


    //Configuracion de volumen

    public void SetVolume( float volume)
    {
        
        musicVolume = volume;
        audioSource.volume = musicVolume;
        dontDestroy.volumenJuego = musicVolume;
    }

}
