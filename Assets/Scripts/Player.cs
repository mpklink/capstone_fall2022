using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class Player : MonoBehaviour
{
    public float movementSpeed = 10;
    public float turningSpeed = 60;

    private GlobalVariables Global;
    Vector3 movement;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        Global = FindObjectOfType<GlobalVariables>();
        //Debug.Log(Global.winning[0].ToString() + " " + Global.winning[1].ToString() + " " + Global.winning[2].ToString() + " " + Global.winning[3].ToString() + " " + Global.winning[4].ToString() + " " + Global.winning[5].ToString());
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal") * turningSpeed * Time.deltaTime;
        transform.Rotate(0, horizontal, 0);

        //float vertical = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;
        //transform.Translate(0, 0, vertical);
        movement = new Vector3(0, 0,Input.GetAxis("Vertical"));

    }

    private void FixedUpdate()
    {
        moveCharacter(movement);
    }

    void moveCharacter(Vector3 direction)
    {
        direction = rb.rotation * direction;

        rb.MovePosition(rb.position + direction * movementSpeed * Time.fixedDeltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("OverworldDoor"))
        {
            //Global.current[0] = other.GetComponent<Building>().BlockNum;
            //Global.current[1] = other.GetComponent<Building>().BuildingNum;
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
            int[] xzValues = new int[2];

            Vector3 bksValues = other.transform.position;

            xzValues = CalculateRowColumn(bksValues.x, bksValues.y);



            Global.current[3] = xzValues[0]; // This is temporary, delete when not needed for testing
            Global.current[4] = xzValues[1]; // This is temporary, delete when not needed for testing
            SceneManager.LoadScene("Bookshelf");
        }
    }

    // This method converts coordinates into a row column # to compare against the pre-gen values for the
    // library scene
    private int[] CalculateRowColumn(float xValue, float zValue)
    {
        int[] result = new int[2];
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
}