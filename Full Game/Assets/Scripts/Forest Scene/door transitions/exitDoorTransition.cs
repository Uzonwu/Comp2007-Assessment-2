using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitDoor : MonoBehaviour
{
    public GameObject theCamera;
    public GameObject playerCamera;
    public GameObject theDoor;
    public AudioSource doorOpen;
    public AudioSource doorClose;

    public void StartExitingSequence()
    {
        StartCoroutine(TheSequence());
    }

    IEnumerator TheSequence()
    {
        theCamera.SetActive(true);

        yield return new WaitForSeconds(3.5f);
        doorOpen.Play();
        theDoor.GetComponent<Animation>().Play("DoorOpenExit");
        yield return new WaitForSeconds(1.25f);
        theCamera.GetComponent<Animation>().Play("MoveCam02");
        yield return new WaitForSeconds(1.95f);
        doorClose.Play();
        yield return new WaitForSeconds(1f);

        // Enable the player camera
        theCamera.SetActive(false);

        // Disable the transition camera
        playerCamera.SetActive(true);
    }
}
