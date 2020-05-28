using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioScript : MonoBehaviour
{

    AudioSource myAudio;
    public static string palabraComparativaAudio;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = dontDestroy.volumenJuego;
    }

    public void hacerSonido()
    {
        switch(dontDestroy.nivelDificultad)
        {
            case 0:
                switch (Palabras.ronda)
                {
                    case 0:
                        palabraComparativaAudio = Palabras.primeraPalabra;
                        break;
                    case 1:
                        palabraComparativaAudio = Palabras.segundaPalabra;
                        break;
                    case 2:
                        palabraComparativaAudio = Palabras.terceraPalabra;
                        break;
                    case 3:
                        palabraComparativaAudio = Palabras.cuartaPalabra;
                        break;
                }
                break;
            case 1:
                switch (PalabrasNormal.ronda)
                {
                    case 0:
                        palabraComparativaAudio = PalabrasNormal.primeraPalabra;
                        break;
                    case 1:
                        palabraComparativaAudio = PalabrasNormal.segundaPalabra;
                        break;
                    case 2:
                        palabraComparativaAudio = PalabrasNormal.terceraPalabra;
                        break;
                    case 3:
                        palabraComparativaAudio = PalabrasNormal.cuartaPalabra;
                        break;
                }
                break;
            case 2:
                switch (PalabrasDificil.ronda)
                {
                    case 0:
                        palabraComparativaAudio = PalabrasDificil.primeraPalabra;
                        break;
                    case 1:
                        palabraComparativaAudio = PalabrasDificil.segundaPalabra;
                        break;
                    case 2:
                        palabraComparativaAudio = PalabrasDificil.terceraPalabra;
                        break;
                    case 3:
                        palabraComparativaAudio = PalabrasDificil.cuartaPalabra;
                        break;
                }
                break;

        }
        
        myAudio = GetComponent<AudioSource>();
        myAudio.clip = Resources.Load<AudioClip>(palabraComparativaAudio);
        myAudio.Play();
    }

    public void SonidoPositivo()
    {

        myAudio = GetComponent<AudioSource>();
        myAudio.clip = Resources.Load<AudioClip>("sonidoPositivo");
        myAudio.Play();
    }

    public void SonidoNegativo()
    {
        myAudio = GetComponent<AudioSource>();
        myAudio.clip = Resources.Load<AudioClip>("sonidoNegativo");
        myAudio.Play();
    }


    public void SonidoFinal()
    {
        myAudio = GetComponent<AudioSource>();
        myAudio.clip = Resources.Load<AudioClip>("sonidoFinal");
        myAudio.Play();
    }

}
