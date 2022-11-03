using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorToLobby : MonoBehaviour
{
    public int BuildingNum;
    public int BlockNum;

    private GlobalVariables Global;

    // Start is called before the first frame update
    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // This probably can be removed.
    private void OnTriggerEnter(Collider collision)
    {
 
        if (collision.gameObject.name == "Player")
        {
            // Get data from building
     
            BuildingNum = GetComponentInParent<Building>().BuildingNum;
            BlockNum = GetComponentInParent<Building>().BlockNum;

            Debug.Log(BuildingNum + " and " + BlockNum);

            // Set Global Variables
            //Global.current[0] = BuildingNum;
            //Global.current[1] = BlockNum;
        }
    }

    public int Get_build_num()
    {
        return BuildingNum;

    }

    public int Get_block_num()
    {
        return BlockNum;

    }


}
