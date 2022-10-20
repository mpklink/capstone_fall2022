using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This script does the selection of a book. */
public class BookSelect : MonoBehaviour
{
    private int[] winning = {50, 50, 50, 50, 50, 10};
    private int[] current = {50, 50, 50, 50, 50, -1};
    
    public GameObject win;
    public GameObject lose;

    private GameObject[] books;
    private GameObject selectedBook;
    private bool endGame = false;

    private void Start()
    {   
        books = GameObject.FindGameObjectsWithTag("Book");
        for(int i = 0; i < books.Length; i++)
        {
            books[i].GetComponent<BookData>().bookNumber = i;
        }
    }

    private void Update()
    {
        if(!endGame)
        {
            for(int i = 0; i < books.Length; i++)
            {
                if (books[i].GetComponent<BookData>().endFound)
                {
                    endGame = true;
                    current[current.Length - 1] = books[i].GetComponent<BookData>().bookNumber;

                    break;
                }
            }
            if(endGame)
            {
                if(CheckLotteryWin())
                {
                    YouWin();
                }
                else
                {
                    YouLose();
                }
                for(int i = 0; i < books.Length; i++)
                {
                    books[i].GetComponent<BookData>().endFound = true;
                }
            }
        }
    }

    private bool CheckLotteryWin()
    {
        for(int i = 0; i < winning.Length; i++)
        {
            if(current[i] != winning[i])
            {
                return false;
            }
        }
        return true;
    }
    
    private void YouWin()
    {
        int bookNumber = current[current.Length - 1];
        Debug.Log("Book " + bookNumber + " is the winner!");
        win.gameObject.SetActive(true);
    }
    private void YouLose()
    {
        int bookNumber = current[current.Length - 1];
        Debug.Log("Book " + bookNumber + " is NOT the winner.");
        lose.gameObject.SetActive(true);
    }

}
