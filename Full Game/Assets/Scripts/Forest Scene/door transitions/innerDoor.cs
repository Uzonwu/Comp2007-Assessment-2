using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class innerDoor : MonoBehaviour, IInteractable
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

        transitionCamera.gameObject.SetActive(true);

        playerCamera.gameObject.SetActive(false);

        if (isInsideDoor)
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
        else
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
    }
    
}
