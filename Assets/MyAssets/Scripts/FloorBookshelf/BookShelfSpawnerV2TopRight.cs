using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookShelfSpawnerV2TopRight : MonoBehaviour
{
    // Whatever our bookshelf object is, we need to pass it in from unity
    [SerializeField]
    GameObject bookShelfPrefab;

    // Pass in the actual floor mesh that we will be spawning bookshelfs on
    /*[SerializeField]
    GameObject floorMeshPrefab;*/

    //The spawn range of the floor object
    float xSpawnRangeLo;
    float xSpawnRangeHi;
    float ySpawnRangeLo;
    float ySpawnRangeHi;
    float zSpawnRangeLo;
    float zSpawnRangeHi;

    // The sizes of the bookshelf collider object
    float xLengthBookShelf;
    float yHeightBookShelf;
    float zWidthBookShelf;

    //Other important stuff
    Quaternion orientation = Quaternion.Euler(0, 0, 0);

    // The amount of space we want between our bookshelves
    public float spaceBetweenShelves;

    //The distance away from the wall that we will spawn the bookshelves, not to include the half length of the object
    public float spaceFromWall;

    //The distance that the next row of bookshelves has from the previous one, not including the width of the object
    public float spaceFromNextRow;

    //Vector3 that holds size info on our bookshelf
    private Vector3 sizeOfBookShelf;

    //Amount of bookshelves we will spawn total
    public int bookShelfsToSpawn;

    //Testing something
    private GameObject floorMesh;


    // Start is called before the first frame update
    void Start()
    {
        /*//Spawn the floor object and get the mesh renderer to get values of x, y , and z
        GameObject tempFloor = Instantiate(floorMeshPrefab, Vector3.zero, Quaternion.identity);
        MeshRenderer tempFloorMeshRenderer = tempFloor.GetComponent<MeshRenderer>();
        
        // Place our found values for the floor mesh into our already initalized floats
        xSpawnRangeLo = tempFloorMeshRenderer.bounds.min.x;
        xSpawnRangeHi = tempFloorMeshRenderer.bounds.max.x;
        ySpawnRangeLo = tempFloorMeshRenderer.bounds.min.y;
        ySpawnRangeHi = tempFloorMeshRenderer.bounds.max.y;
        zSpawnRangeLo = tempFloorMeshRenderer.bounds.min.z;
        zSpawnRangeHi = tempFloorMeshRenderer.bounds.max.z;

        // Remove that floor, as we only need it to get coordinates, the object already exists in our scene so destroy it
        Destroy(tempFloor);*/

        // Get sizes and scale of our plane where the shelves are gonna go
        floorMesh = GameObject.Find("BookShelfPlaneTopRight");
        Vector3 positionFloor = floorMesh.transform.position;
        Vector3 scaleFloor = floorMesh.transform.localScale;
        Debug.Log(positionFloor.ToString());
        Debug.Log(scaleFloor.ToString());

        //Now convert it so we can get the top corner coordinates so we can start spawning

        xSpawnRangeLo = positionFloor.x - ((scaleFloor.x / 2) * 10);
        xSpawnRangeHi = positionFloor.x + ((scaleFloor.x / 2) * 10);

        zSpawnRangeHi = positionFloor.z + ((scaleFloor.z / 2) * 10);
        zSpawnRangeLo = positionFloor.z + ((scaleFloor.z / 2) * 10);

        // Now find the sizes of the bookshelf object
        sizeOfBookShelf = bookShelfPrefab.transform.localScale;
        xLengthBookShelf = sizeOfBookShelf.x;
        yHeightBookShelf = sizeOfBookShelf.y;
        zWidthBookShelf = sizeOfBookShelf.z;

        /*Debug.Log("Length of BookShelf = " + xLengthBookShelf);      //Check it looks good, which it does
        Debug.Log("Height of BookShelf = " + yHeightBookShelf);
        Debug.Log("Width of BookShelf = " + zWidthBookShelf);*/

        //Prep conditions for the for loop
        float trueSpaceFromWall = spaceFromWall + (xLengthBookShelf / 2); // This ensures correct amount so we have to add length  
        float trueSpaceBetweenShelves = xLengthBookShelf + spaceBetweenShelves; //Ensures space corrected due to length of bookshelf
        float trueSpaceFromNextRow = spaceFromNextRow + zWidthBookShelf;

        //Initial values from our mesh
        float xHelper = xSpawnRangeLo + trueSpaceFromWall; // Moves bookshelf along current row --> -->
        float zHelper = zSpawnRangeHi - (zWidthBookShelf / 2); // Moves bookshelf down a ROW (Imagine this is a down arrow cause idk how to comment it)

        for (int i = 0; i < bookShelfsToSpawn; i++)
        {
            // Our x value is at the top left, meaning that we will start at a negative x and progressivly move to a positive on
            // Thus we need to check if we are still in the mesh paramaters, so our xHelper will help us do this comparison
            if (xHelper < xSpawnRangeHi)
            {
                //Still in our row so keep spawining on the same z
                Vector3 pos = new Vector3(xHelper, (yHeightBookShelf / 2), zHelper);
                SpawnBookShelf(pos);
                xHelper += trueSpaceBetweenShelves;
            }
            // We reached the other side of the mesh, so we must create a new row
            else
            {
                xHelper = xSpawnRangeLo + trueSpaceFromWall;  //Reset the x value and continue on a lower z
                zHelper -= trueSpaceFromNextRow;
                Vector3 pos = new Vector3(xHelper, (yHeightBookShelf / 2), zHelper);
                SpawnBookShelf(pos);
            }
        }




    }

    // Method to handle spawning of bookshelves from vector3 position
    GameObject SpawnBookShelf(Vector3 position)
    {
        return Instantiate(bookShelfPrefab, position, orientation);
    }

}
