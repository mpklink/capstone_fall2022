using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightWinningShelf : MonoBehaviour
{
    [SerializeField]
    GameObject winningKookShelfPrefab;

    private GlobalVariables Global;

    // Start is called before the first frame update
    void Start()
    {
        /*Global = FindObjectOfType<GlobalVariables>();
        float[] winningBookshelf = new float[2];
        winningBookshelf = CalculateRowColumn(Global.winning[3]);
        Debug.Log("xValue is: " + winningBookshelf[0]);
        Debug.Log("zValue is: " + winningBookshelf[1]);

        Vector3 pos = new Vector3(winningBookshelf[0], 2.5f, winningBookshelf[1]);
        Quaternion orientation = Quaternion.Euler(0, 0, 0);

        Instantiate(winningKookShelfPrefab, pos, orientation);

        int bookShelfNum = CalculateBookShelfNumber(winningBookshelf[0], winningBookshelf[1]);

        Debug.Log("Bookshelf Number is: " + bookShelfNum);*/
    }


    /*public static float[] CalculateCoordinates(int bookshelfNumber)
    {
        float[] winningBookshelf = new float[2];

        // xValue stuff
        int bookShelvesInRow = 68;
        float initialXValue = -183.5f;
        float spaceBetweenBookShelves = 5f;
        float deadSpaceX = 22f;

        // zValue stuff
        int bookShelvesinColumn = 70;
        float initialZValue = 184.5f;
        float spaceBetweenRows = 5f;
        float deadSpaceZ = 24f;


        float xValue = 0f;
        float zValue = 0f;

        // Value 4761 is reserved for the bookshelf at (0,0) this one is #4761  
        if (bookshelfNumber != 4761)
        {
            // Find x value first
            int helper = bookshelfNumber % bookShelvesInRow;
            if (helper == 0)
            {
                xValue = initialXValue + (bookShelvesInRow * spaceBetweenBookShelves) + deadSpaceX;
            }
            else if (helper <= (bookShelvesInRow / 2))
            {
                xValue = initialXValue + (helper * 5);
            }
            else // helper > 34
            {
                xValue = initialXValue + (helper * 5) + deadSpaceX;
            }

            // Find z value
            int helper2 = bookshelfNumber / bookShelvesInRow;
            //int helper2 = (value1 * value2) % bookShelvesinColumn;
            if (helper2 == 0)
            {
                zValue = initialZValue;
            }
            else if (helper2 < (bookShelvesinColumn / 2))
            {
                zValue = initialZValue - (helper2 * spaceBetweenRows);
            }
            else // helper2 > 35
            {
                zValue = initialZValue - (helper2 * spaceBetweenRows) - deadSpaceZ;
            }
        }

        winningBookshelf[0] = xValue;
        winningBookshelf[1] = zValue;
        return winningBookshelf;
    }*/

    // This method converts coordinates into a row column # to compare against the pre-gen values
    public static float[] CalculateRowColumn(float xValue, float zValue)
    {
        float[] result = new float[2];
        int rowNum = 0;
        int columnNum = 0;
        // Find the row number using our zValue  
        if (zValue > 0)
        {
            rowNum = (int)(((184.5f - zValue) / 5f) + 1f);
        }

        else if (zValue < 0)
        {
            rowNum = (int)(((184.5f - zValue + 1f) / 5f) + 4f);
        }

        // Find the column number using our xValue     
        if (xValue < 0)
        {
            columnNum = (int)(((178.5f + xValue) / 5f) + 1f);
        }

        else if (xValue > 0)
        {
            columnNum = (int)(((178.5f + xValue - 2) / 5f) - 3f);
        }
        Debug.Log("Row number is: " + rowNum);
        Debug.Log("Column Number is: " + columnNum);
        return result;
    }

    /*public static int CalculateBookShelfNumberFromRowColumn(int row, int column)
    {
        int bookshelfNumber = (row * 69) - (69 - column);
        return bookshelfNumber;
    }*/

}