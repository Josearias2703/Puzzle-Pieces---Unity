using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateImagen : MonoBehaviour
{
    public Sprite imageFace;

    private SpriteRenderer spriteRenderer;
    private Selectable selectable;
    private Palabras palabras;

    void Start()
    {
        CrearImagen();

    }

    public void CrearImagen()
    {
        List<string> deck = Palabras.GenerateImages();   //se genera lista donde string (s+v) y los sprites (caras de cartas) son las mismas
        palabras = FindObjectOfType<Palabras>(); //para acceder a los sprites de Memory (caras de cartas)

        //loop que matches nombre de tarjeta (sprite) con el string (s+v)
        int i = 0;
        foreach (string imagen in deck)
        {

            if (this.name == imagen) // si el nombre de tarjeta (sprint) es igual a string (s+v)
            {
                imageFace = palabras.imageFaces[i];  //se guardan las caras de cartas en el cardFace
                break;
            }
            i++;

        }

        spriteRenderer = GetComponent<SpriteRenderer>();    //sprite renderer componenete de carta en inspector
        selectable = GetComponent<Selectable>();

    }
    // Update is called once per frame
    void Update()
    {
        spriteRenderer.sprite = imageFace;

    }
}
