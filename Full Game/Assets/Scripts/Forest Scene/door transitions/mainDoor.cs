using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainDoor : MonoBehaviour, IInteractable
{
    public GameObject enterManager;
    public GameObject exitManager;
    public Camera transitionCamera;
    public Camera playerCamera;
    public Transform insideDestination; 
    public Transform outsideDestination;

    private bool isInsideDoor = false;
    public void OnInteract()
    {
        isInsideDoor = !isInsideDoor;

        // Enable the transition camera
        transitionCamera.gameObject.SetActive(true);

        // Disable the player camera
        playerCamera.gameObject.SetActive(false);

        if (isInsideDoor)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                player.SetActive(false);
                player.transform.position = insideDestination.position;
                player.SetActive(true);
            }

            enterManager.gameObject.SetActive(true);
            enterManager.GetComponent<EntranceDoor>().StartEnteringSequence();

        }
        else
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                player.SetActive(false);
                player.transform.position = outsideDestination.position;
                player.SetActive(true);
            }

            exitManager.gameObject.SetActive(true);
            exitManager.GetComponent<ExitDoor>().StartExitingSequence();

        }
    }
}
