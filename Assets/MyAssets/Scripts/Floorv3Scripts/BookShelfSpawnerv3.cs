using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookShelfSpawnerv3 : MonoBehaviour
{
    [SerializeField]
    GameObject bookShelfPrefab;

    [SerializeField]
    GameObject floorMeshPrefab;

    // Values to catch our floor 
    float xSpawnRangeLo;
    float xSpawnRangeHi;
    float ySpawnRangeLo;
    float ySpawnRangeHi;
    float zSpawnRangeLo;
    float zSpawnRangeHi;

    // How much space between bookshelves in the row
    public float spaceBetweenShelves;

    // How much space we want between the rows
    public float spaceBetweenRows;

    // How many bookshelves to spawn
    public int bookShelfsToSpawn;

    // How many bookshelves to spawn
    public int bookShelvesinRow = 34;

    Quaternion orientation = Quaternion.Euler(0, 0, 0);


    // Start is called before the first frame update
    void Start()
    {
        Vector3 positionFloor = floorMeshPrefab.transform.position;
        GameObject tempFloor = Instantiate(floorMeshPrefab, positionFloor, Quaternion.identity);
        MeshRenderer tempFloorMeshRenderer = tempFloor.GetComponent<MeshRenderer>();

        xSpawnRangeLo = tempFloorMeshRenderer.bounds.min.x;
        xSpawnRangeHi = tempFloorMeshRenderer.bounds.max.x;
        ySpawnRangeLo = tempFloorMeshRenderer.bounds.min.y;
        ySpawnRangeHi = tempFloorMeshRenderer.bounds.max.y;
        zSpawnRangeLo = tempFloorMeshRenderer.bounds.min.z;
        zSpawnRangeHi = tempFloorMeshRenderer.bounds.max.z;

        Destroy(tempFloor);

        //Debug stuff
        Debug.Log("xSpawnRangeLo is: " + xSpawnRangeLo);

        Debug.Log("zSpawnRangeLo is: " + zSpawnRangeLo);

        Debug.Log("zSpawnRangeHi is: " + zSpawnRangeHi);

        // Check to see if we are in negatgive x's (2nd or 4th quadrant), meaning the start of our spawning is at -112
        // We thus need to ADD the value of space between our shelves
        /*if (xSpawnRangeHi < 0)
        {
            xHelper = xSpawnRangeLo + 
        }*/


        // 
        float resetxHelper = xSpawnRangeLo + 1.5f + 2f;
        float xHelper = resetxHelper; // row value that lets us place on the row
        float zHelper = zSpawnRangeHi - 0.5f - spaceBetweenRows; // Edge where we are starting

        float trueSpaceBetweenShleves = spaceBetweenShelves + 3f;
        float trueSpaceBetweenRows = spaceBetweenRows + 1f;

        int counter = 0;
        bookShelvesinRow -= 1;

        for (int i = 0; i < bookShelfsToSpawn; i++)
        {
            Vector3 pos = new Vector3(xHelper, 2.5f, zHelper);
            SpawnBookShelf(pos);

            //Initial Condition
            if (counter < bookShelvesinRow)
            {
                xHelper += trueSpaceBetweenShleves;
                counter++;
            }
            else
            {
                xHelper = resetxHelper;  //Position where shelf is offset by 1.5 aka half the x scale
                zHelper -= trueSpaceBetweenRows;
                counter = 0;
            }

        }


    }

    // Method to handle spawning of bookshelves from vector3 position
    GameObject SpawnBookShelf(Vector3 position)
    {
        return Instantiate(bookShelfPrefab, position, orientation);
    }
}
