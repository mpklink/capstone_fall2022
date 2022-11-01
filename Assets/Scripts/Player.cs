using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 2.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;

    private GlobalVariables Global;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        Global = FindObjectOfType<GlobalVariables>();
        Console.WriteLine(Global.winning[0].ToString() + " " + Global.winning[1].ToString() + " " + Global.winning[2].ToString() + " " + Global.winning[3].ToString() + " " + Global.winning[4].ToString() + " " + Global.winning[5].ToString());
    }

    // Update is called once per frame
    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("OverworldDoor"))
        {
            //GlobalVariables.current[0] = other.GetComponent<Building>().BlockNum;
            //GlobalVariables.current[1] = other.GetComponent<Building>().BuildingNum;
            Global.current[0] = Global.winning[0]; // This is temporary, delete when not needed for testing
            Global.current[1] = Global.winning[1]; // This is temporary, delete when not needed for testing
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
