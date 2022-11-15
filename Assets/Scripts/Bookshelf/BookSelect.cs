using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This script does the selection of a book. */
public class BookSelect : MonoBehaviour
{
    //private int[] winningNumbers = {50, 50, 50, 50, 50, 10};
    //private int[] currentNumbers = {50, 50, 50, 50, 50, -1};
    
    public GameObject win;
    public GameObject lose;

    private GameObject[] books;
    private GameObject selectedBook;
    private bool endGame = false;

    private GlobalVariables Global;

    private void Start()
    {   
        Global = FindObjectOfType<GlobalVariables>();

        books = GameObject.FindGameObjectsWithTag("Book");
        Debug.Log("Total Books: " + books.Length);
        /*for(int i = 0; i < books.Length; i++)
        {
            books[i].GetComponent<BookData>().bookNumber = i;
        }*/
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
                    Global.current[Global.current.Length - 1] = books[i].GetComponent<BookData>().bookNumber;
                    //Global.current[5] = Global.winning[5];

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
        bool winLottery = true;
        string winning = "winning: ";
        string current = "current: ";
        for(int i = 0; i < Global.winning.Length; i++)
        {
            if(Global.current[i] != Global.winning[i])
            {
                winLottery = false;
            }
            winning = winning + Global.winning[i] + "  ";
            current = current + Global.current[i] + "  ";
        }
        Debug.Log(winning);
        Debug.Log(current);
        return winLottery;
    }
    
    private void YouWin()
    {
        int bookNumber = Global.current[Global.current.Length - 1];
        Debug.Log("Book " + bookNumber + " is the winner!");
        win.gameObject.SetActive(true);
    }
    private void YouLose()
    {
        int bookNumber = Global.current[Global.current.Length - 1];
        Debug.Log("Book " + bookNumber + " is NOT the winner.");
        lose.gameObject.SetActive(true);
    }

}