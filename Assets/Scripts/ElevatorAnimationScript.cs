using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ElevatorAnimationScript : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private UI_InputWindow inputWindow;

    // Start is called before the first frame update


    // Update is called once per frame

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && gameObject.tag == "Elevator")
        {
            other.gameObject.SetActive(false);
            Debug.Log("Triggered");
            inputWindow.Show();

            anim.SetBool("openDoor", false);
            anim.SetBool("closeDoor", true);
            anim.SetBool("goUp", true);
        }
        else if (other.CompareTag("Player") && gameObject.tag == "DoorOpener")
        {
            Debug.Log("Stairs");
            anim.SetBool("closeDoor", false);
            anim.SetBool("openDoor", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && gameObject.tag == "DoorOpener")
        {
            Debug.Log("ExitStairs");
            anim.SetBool("openDoor", false);
            anim.SetBool("closeDoor", true);
        }
    }
}
