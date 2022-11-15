using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookSpawn : MonoBehaviour
{
    
    public GameObject book;
    public float lengthBetweenBooks;
    public float thicknessOfSide;
    public float thicknessOfTop;
    public float bookDistanceFromShelf;
    public int totalBooks;
    public int totalRows;

    private Vector3 shelfPosition;
    private Vector3 shelfScale;
    private Vector3 bookPosition;
    private Vector3 bookScale;
    private int bookCount;
    private int totalColumns;

    void Awake()
    {
        shelfPosition = gameObject.transform.position;
        shelfScale = gameObject.transform.localScale;
        
        totalColumns = totalBooks / totalRows;
        bookCount = 0;
        
        GameObject bookEnd = book.transform.GetChild(0).gameObject;
        bookScale = new Vector3(bookEnd.transform.localScale.x * book.transform.localScale.x, bookEnd.transform.localScale.y * book.transform.localScale.y, bookEnd.transform.localScale.z * book.transform.localScale.z);
        bookPosition = new Vector3(shelfPosition.x - shelfScale.x/2 - bookScale.x/2 + thicknessOfSide, shelfPosition.y + shelfScale.y/2 + bookScale.y/2, shelfPosition.z + shelfScale.z/2 - bookDistanceFromShelf);

        for(int i = 0; i < totalRows; i++)
        {
            bookPosition.y -= thicknessOfTop + bookScale.y;
            for(int j = 0; j < totalColumns; j++)
            {
                bookPosition.x += lengthBetweenBooks + bookScale.x;
                
                GameObject newBook = Instantiate(book);
                
                newBook.transform.position = bookPosition;
                bookCount++;
                newBook.transform.GetChild(0).gameObject.GetComponent<BookData>().bookNumber = bookCount;
            }
            bookPosition.x = shelfPosition.x - shelfScale.x/2 - bookScale.x/2 + thicknessOfSide;
        }
    }
}
