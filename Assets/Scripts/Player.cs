using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float movementSpeed = 10;
    public float turningSpeed = 60;

    private GlobalVariables Global;
    // Start is called before the first frame update
    void Start()
    {
        Global = FindObjectOfType<GlobalVariables>();
        //Debug.Log(Global.winning[0].ToString() + " " + Global.winning[1].ToString() + " " + Global.winning[2].ToString() + " " + Global.winning[3].ToString() + " " + Global.winning[4].ToString() + " " + Global.winning[5].ToString());
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal") * turningSpeed * Time.deltaTime;
        transform.Rotate(0, horizontal, 0);

        float vertical = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;
        transform.Translate(0, 0, vertical);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("OverworldDoor"))
        {
            Global.current[0] = other.GetComponent<Building>().BlockNum;
            Global.current[1] = other.GetComponent<Building>().BuildingNum;
            Debug.Log(Global.current[0] + " and " + Global.current[1]);
            //Global.current[0] = Global.winning[0]; // This is temporary, delete when not needed for testing
            //Global.current[1] = Global.winning[1]; // This is temporary, delete when not needed for testing
            SceneManager.LoadScene("Lobby");
        }
        if (other.CompareTag("LobbyToLibrary"))
        {
            //GlobalVariables.current[0] = other.GetComponent<Building>().BlockNum;
            //GlobalVariables.current[1] = other.GetComponent<Building>().BuildingNum;
            Global.current[2] = Global.winning[2]; // This is temporary, delete when not needed for testing
            SceneManager.LoadScene("LibraryFloor");
        }
        if (other.CompareTag("BookShelf1"))
        {
            //GlobalVariables.current[0] = other.GetComponent<Building>().BlockNum;
            //GlobalVariables.current[1] = other.GetComponent<Building>().BuildingNum;
            Global.current[3] = Global.winning[3]; // This is temporary, delete when not needed for testing
            Global.current[4] = Global.winning[4]; // This is temporary, delete when not needed for testing
            SceneManager.LoadScene("Bookshelf");
        }
    }
}