using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateLetraNormal : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite letterFace;

    private SpriteRenderer spriteRenderer;
    private Selectable selectable;
    private PalabrasNormal palabras;

    void Start()
    {
        CrearLetras();

    }

    public void CrearLetras()
    {
        List<string> deck = PalabrasNormal.GenerateAlphabet();   //se genera lista donde string (s+v) y los sprites (caras de cartas) son las mismas
        palabras = FindObjectOfType<PalabrasNormal>(); //para acceder a los sprites de Memory (caras de cartas)

        //loop que matches nombre de tarjeta (sprite) con el string (s+v)
        int i = 0;
        foreach (string letra in deck)
        {

            if (this.name == letra) // si el nombre de tarjeta (sprint) es igual a string (s+v)
            {
                letterFace = palabras.letterFaces[i];  //se guardan las caras de cartas en el cardFace
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
        spriteRenderer.sprite = letterFace;

    }
}
