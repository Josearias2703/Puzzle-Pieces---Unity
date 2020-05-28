using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateSpriteDificil : MonoBehaviour
{
    // metodo de prefab Carta
    //Emparejar partes delanteras de cartas con prefab.

    public Sprite cardFace;
    public Sprite cardBack;

    //acceso al spriteRenderer, el script de Selectable y Script de Memory ya que ahi estan los sprits (las caras de las cartas)
    private SpriteRenderer spriteRenderer;
    private Selectable selectable;
    private MemoryDificil memory;


    // Start is called before the first frame update
    void Start()
    {
        CrearCartas();
    }

    public void CrearCartas()
    {

        List<string> deck = MemoryDificil.GenerateDeck();   //se genera lista donde string (s+v) y los sprites (caras de cartas) son las mismas
        memory = FindObjectOfType<MemoryDificil>(); //para acceder a los sprites de Memory (caras de cartas)

        //loop que matches nombre de tarjeta (sprite) con el string (s+v)
        int i = 0;
        foreach (string card in deck)
        {

            if (this.name == card) // si el nombre de tarjeta (sprint) es igual a string (s+v)
            {
                cardFace = memory.cardFaces[i];  //se guardan las caras de cartas en el cardFace
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
         
       if(selectable.faceUp == true)
       {
            spriteRenderer.sprite = cardFace;
       }
        else
       {
            spriteRenderer.sprite = cardBack;
       }
    }
}
