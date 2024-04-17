using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    public GameObject normalFootstep;
    public GameObject sprintFootstep;
    public GameObject indoorNormalFootstep;
    public GameObject indoorSprintFootstep;

    private bool isSprinting = false;
    private bool isInIndoorZone = false;

    void Start()
    {
        normalFootstep.SetActive(false);
        sprintFootstep.SetActive(false);
        indoorNormalFootstep.SetActive(false);
        indoorSprintFootstep.SetActive(false);
    }

    void Update()
    {
        if (!isInIndoorZone)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
            {
                NormalFootsteps();
            }

            if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D))
            {
                StopFootsteps();
            }

            if (Input.GetKey(KeyCode.LeftShift))
            {
                isSprinting = true;
                if (!sprintFootstep.activeSelf)
                {
                    sprintFootstep.SetActive(true);
                    normalFootstep.SetActive(false);
                }
            }
            else
            {
                isSprinting = false;
                sprintFootstep.SetActive(false);
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
            {
                IndoorNormalFootsteps();
            }

            if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D))
            {
                IndoorStopFootsteps();
            }

            if (Input.GetKey(KeyCode.LeftShift))
            {
                isSprinting = true;
                if (!indoorSprintFootstep.activeSelf)
                {
                    indoorSprintFootstep.SetActive(true);
                    indoorNormalFootstep.SetActive(false);
                }
            }
            else
            {
                isSprinting = false;
                indoorSprintFootstep.SetActive(false);
            }
        }
    }

    void NormalFootsteps()
    {
        if (!normalFootstep.activeSelf && !isInIndoorZone)
        {
            normalFootstep.SetActive(true);
        }
    }

    void StopFootsteps()
    {
       if (normalFootstep.activeSelf)
        {
            normalFootstep.SetActive(false);
        }
        if (isSprinting)
        {
            sprintFootstep.SetActive(false);
        }
    }

    void IndoorNormalFootsteps()
    {
        if (!indoorNormalFootstep.activeSelf)
        {
            indoorNormalFootstep.SetActive(true);
        }
    }

    void IndoorStopFootsteps()
    {
        indoorNormalFootstep.SetActive(false);
        if (isSprinting)
        {
            indoorSprintFootstep.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("IndoorZone"))
        {
            isInIndoorZone = true;
            StopFootsteps();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("IndoorZone"))
        {
            isInIndoorZone = false;
            IndoorStopFootsteps();
        }
    }
}
