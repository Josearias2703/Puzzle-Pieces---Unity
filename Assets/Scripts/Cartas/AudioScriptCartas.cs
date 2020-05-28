using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScriptCartas : MonoBehaviour
{
    AudioSource myAudio;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = dontDestroy.volumenJuego;
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
