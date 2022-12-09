using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookData : MonoBehaviour
{
    public int bookNumber;              // The numerical order that the book is in.
    public Material glowMaterial;       // The material that the book uses when the mouse is over it.
    private Material defaultMaterial;   // The default material of the book.
    private Behaviour halo;             // The halo component of the book. It is turned OFF by default.

    public bool endFound = false;

    public AudioClip mouseOverSound;
    private AudioSource audioSource;
    private bool soundPlayed = false;

    // Start is called before the first frame update
    void Start()
    {
        defaultMaterial = GetComponent<MeshRenderer>().material;
        halo = (Behaviour)GetComponent("Halo");
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(Input.GetMouseButtonUp(0))
        {
            halo.enabled = false;
        }
    }

    private void OnMouseOver(){
        if(!endFound)
        {
            if(!soundPlayed) {
                int volumeAdjustment = (bookNumber - 1) / 5;
                audioSource.PlayOneShot(mouseOverSound, 0.5f + (float)volumeAdjustment/4.0f);
                soundPlayed = true;
            }
            GetComponent<MeshRenderer>().material = glowMaterial;

            // Check for left mouse click.
            if(Input.GetMouseButtonDown(0)){
                halo.enabled = true;
                endFound = true;
            }
        }
    }

    private void OnMouseExit()
    {
        GetComponent<MeshRenderer>().material = defaultMaterial;
        soundPlayed = false;
    }

}
