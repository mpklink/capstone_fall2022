using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookshelfSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject bookShelfPrefab;

    [SerializeField]
    GameObject floorMeshPrefab;

    public int bookShelfsToSpawn;

    public float spaceBetweenShelves;

    public float spaceFromWall;




    float xSpawnRangeLo;
    float xSpawnRangeHi;
    float ySpawnRangeLo;
    float ySpawnRangeHi;
    float zSpawnRangeLo;
    float zSpawnRangeHi;

    float xBookShelfRangeLo;
    float xBookShelfRangeHi;
    float yBookShelfRangeLo;
    float yBookShelfRangeHi;
    float zBookShelfRangeLo;
    float zBookShelfRangeHi;


    Quaternion orientation = Quaternion.Euler(0, 0, 0);


    // Start is called before the first frame update
    void Start()
    {
        GameObject tempFloor = Instantiate(floorMeshPrefab, Vector3.zero, Quaternion.identity);
        MeshRenderer tempFloorMeshRenderer = tempFloor.GetComponent<MeshRenderer>();




        xSpawnRangeLo = tempFloorMeshRenderer.bounds.min.x;
        xSpawnRangeHi = tempFloorMeshRenderer.bounds.max.x;
        ySpawnRangeLo = tempFloorMeshRenderer.bounds.min.y;
        ySpawnRangeHi = tempFloorMeshRenderer.bounds.max.y;
        zSpawnRangeLo = tempFloorMeshRenderer.bounds.min.z;
        zSpawnRangeHi = tempFloorMeshRenderer.bounds.max.z;

        Destroy(tempFloor);


        //Get bounds of bookshelf object

        //GameObject tempBookShelf = Instantiate(bookShelfPrefab, Vector3.zero, Quaternion.identity);
        //MeshRenderer tempBookShelfMeshRenderer = tempBookShelf.GetComponent<MeshRenderer>();

        /*GameObject tempBookShelf = Instantiate(bookShelfPrefab, Vector3.zero, Quaternion.identity);
        MeshRenderer tempBookShelfMeshRenderer = tempBookShelf.GetComponent<MeshRenderer>();

        xBookShelfRangeLo = tempBookShelfMeshRenderer.transform.localScale;
        xBookShelfRangeHi = tempBookShelfMeshRenderer.bounds.max.x;

        yBookShelfRangeLo = tempBookShelfMeshRenderer.bounds.min.y;
        yBookShelfRangeHi = tempBookShelfMeshRenderer.bounds.max.y;

        zBookShelfRangeLo = tempBookShelfMeshRenderer.bounds.min.z;
        zBookShelfRangeHi = tempBookShelfMeshRenderer.bounds.max.z;
        
        //Destroy(tempBookShelf);

        //Get Dimensions of bookshelf object

        float widthBookShelf = zBookShelfRangeHi * 2;
        Debug.Log("BookShelf Width is: " + widthBookShelf);

        float lengthBookShelf = xBookShelfRangeHi * 2;
        Debug.Log("BookShelf length is: " + widthBookShelf);

        float heightBookShelf = yBookShelfRangeHi * 2;
        Debug.Log("BookShelf height is: " + widthBookShelf);*/








        //initial values
        float xHelper = xSpawnRangeHi - 1.5f; // row we are on
        float zHelper = zSpawnRangeHi - 1.5f; // Edge where we are starting

        for (int i = 0; i < bookShelfsToSpawn; i++)
        {
            //Initial Condition
            if (zHelper > zSpawnRangeLo)
            {
                Vector3 pos = new Vector3(xHelper, 2.5f, zHelper);
                SpawnBookShelf(pos);
                zHelper -= spaceBetweenShelves;
            }
            else
            {
                zHelper = 248.5f;  //Position where shelf is offset by 1.5 aka half the x scale
                xHelper -= spaceBetweenShelves;
                Vector3 pos = new Vector3(xHelper, 2.5f, zHelper);
                SpawnBookShelf(pos);
            }

        }
    }


    GameObject SpawnBookShelf(Vector3 position)
    {

        //Initial Condition

        return Instantiate(bookShelfPrefab, position, orientation);

    }
}
