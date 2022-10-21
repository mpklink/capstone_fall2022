using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This script does the selection of a book. */
public class BookSelect : MonoBehaviour
{
    
    public int bookNumber;              // The numerical order that the book is in.
    public int lotteryNumber;           // The winning numerical value for the lottery.
    public Material glowMaterial;       // The material that the book uses when the mouse is over it.
    private Material defaultMaterial;   // The default material of the book.
    private Behaviour halo;             // The halo component of the book. It is turned OFF by default.

    private void Start()
    {
        defaultMaterial = GetComponent<MeshRenderer>().material; 
        halo = (Behaviour)GetComponent("Halo");
    }

    private void Update()
    {
        if(Input.GetMouseButtonUp(0))
        {
            halo.enabled = false;
        }
    }

    private void OnMouseOver(){
        GetComponent<MeshRenderer>().material = glowMaterial;
        
        // Check for left mouse click.
        if(Input.GetMouseButtonDown(0)){
            halo.enabled = true;
            if(CheckLottery())
            {
                Debug.Log("Book " + bookNumber + " is the winner!");
            }
            else
            {
                Debug.Log("Book " + bookNumber + " is NOT the winner.");
            }
        }
    }

    private void OnMouseExit()
    {
        GetComponent<MeshRenderer>().material = defaultMaterial;
    }

    private bool CheckLottery()
    {
        return bookNumber == lotteryNumber;
    }
}
