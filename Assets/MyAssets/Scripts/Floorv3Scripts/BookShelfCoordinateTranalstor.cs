using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookShelfCoordinateTranalstor : MonoBehaviour
{
    // Takes in the two values between 1 - 69 and calculates which bookshelf it goes to
    public static float[] CalculateCoordinates(int value1, int value2)
    {
        float[] winningBookshelf = new float[2];
        
        // xValue stuff
        int bookShelvesInRow = 68;
        float initialXValue = -183.5f;
        float spaceBetweenBookShelves = 5f;
        float deadSpaceX = 22f;

        // zValue stuff
        int bookShelvesinColumn = 70;
        float initialZValue = 189.5f;
        float spaceBetweenRows = 5f;
        float deadSpaceZ = 24f;


        float xValue = 0f;
        float zValue = 0f;

        // Value 4761 is reserved for the bookshelf at (0,0)  
        if (value1 * value2 != 4761)
        {
            // Find x value first
            int helper = (value1 * value2) % bookShelvesInRow;
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
            int helper2 = (value1 * value2) % bookShelvesinColumn;
            if (helper2 == 0)
            {
                zValue = initialZValue - (bookShelvesinColumn * spaceBetweenRows) - deadSpaceZ;
            }
            else if (helper <= (bookShelvesinColumn / 2))
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
    }
}
