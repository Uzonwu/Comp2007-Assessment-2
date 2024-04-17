using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class textManager : MonoBehaviour
{
    public TextMeshProUGUI firstText;
    public TextMeshProUGUI secondText;
    public TextMeshProUGUI thirdText;
    public TextMeshProUGUI fourthText;

    public AudioSource snap;
    public TextMeshProUGUI snapAlert;
    public float snapInterval = 40f;

    private PlayerInventory playerInventory;

    void Start()
    {
        playerInventory = FindObjectOfType<PlayerInventory>();

        if (playerInventory != null)
        {
            playerInventory.OnItemsCollected.AddListener(OnItemsCollected);
        }

        StartCoroutine(DisplayIntros());
        StartCoroutine(PlaySnapRepeatedly());
        StartCoroutine(DisplayAlertAfterDelay());
    }

    IEnumerator DisplayIntros()
    {
        yield return new WaitForSeconds(1f);

        firstText.gameObject.SetActive(true);

        yield return new WaitForSeconds(5f);

        firstText.gameObject.SetActive(false);

        secondText.gameObject.SetActive(true);

        yield return new WaitForSeconds(6f);

        secondText.gameObject.SetActive(false);
    }

    void OnItemsCollected(PlayerInventory inventory)
    {
        
        if (inventory.NumberOfItems == 1)
        {
            thirdText.gameObject.SetActive(true);

            StartCoroutine(ItemFound());
        }
    }

    IEnumerator ItemFound()
    {
        yield return new WaitForSeconds(5f);

        thirdText.gameObject.SetActive(false);

        fourthText.gameObject.SetActive(true);

        yield return new WaitForSeconds(3f);

        fourthText.gameObject.SetActive(false);
    }

    IEnumerator PlaySnapRepeatedly()
    {
        // Play the sound after 40 seconds from the start of the game
        yield return new WaitForSeconds(30f);

        while (true)
        {
            snap.Play(); // Play the sound
            yield return new WaitForSeconds(snapInterval); // Wait for the specified interval
        }
    }

    IEnumerator DisplayAlertAfterDelay()
    {
        // Display the text after 40 seconds from the start of the game
        yield return new WaitForSeconds(30.5f);

        snapAlert.gameObject.SetActive(true);
        yield return new WaitForSeconds(4f);
        snapAlert.gameObject.SetActive(false);
    }
}
