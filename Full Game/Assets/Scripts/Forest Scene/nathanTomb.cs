using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class NathanTomb : MonoBehaviour, IInteractable
{
    public GameObject blackScreen; 
    public TextMeshProUGUI displayText;
    public TextMeshProUGUI displayInstructions;

    public TextMeshProUGUI failedText;

    public TextMeshProUGUI winText1;
    public TextMeshProUGUI winText2;
    public TextMeshProUGUI winText3;
    public TextMeshProUGUI winText4;

    private PlayerInventory playerInventory;

    private bool isInteractable = true;
    private bool hasWon = false;

    void Start()
    {
        displayText.gameObject.SetActive(false);
        failedText.gameObject.SetActive(false);
        winText1.gameObject.SetActive(false);

        playerInventory = FindObjectOfType<PlayerInventory>();

        if (playerInventory != null)
        {
            playerInventory.OnItemsCollected.AddListener(OnItemsCollected);
        }

    }

    public void OnInteract()
    {
        if (isInteractable)
        {
            displayText.gameObject.SetActive(true);

            StartCoroutine(ExpositoryText());
        }
    }

    IEnumerator ExpositoryText()
    {
        yield return new WaitForSeconds(5f);
        displayText.gameObject.SetActive(false);
        displayInstructions.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        displayInstructions.gameObject.SetActive(false);

    }

    void OnItemsCollected(PlayerInventory inventory)
    {
        Update();
    }

    IEnumerator CheckForWin()
    {
        yield return new WaitForSeconds(0.1f);
        if (hasWon)
            yield break;

        if (playerInventory != null && playerInventory.NumberOfItems == 10)
        {
            hasWon = true;
            blackScreen.GetComponent<Animation>().Play("fading to black");
            winText1.gameObject.SetActive(true);
            yield return new WaitForSeconds(5f);
            winText1.gameObject.SetActive(false);

            winText2.gameObject.SetActive(true);
            yield return new WaitForSeconds(5f);
            winText2.gameObject.SetActive(false);

            winText3.gameObject.SetActive(true);
            yield return new WaitForSeconds(5f);
            winText3.gameObject.SetActive(false);

            winText4.gameObject.SetActive(true);
            yield return new WaitForSeconds(5f);
            winText4.gameObject.SetActive(false);

            SceneManager.LoadScene(0);
        }
        else if (playerInventory != null && playerInventory.NumberOfItems != 10)
        {
            failedText.gameObject.SetActive(true);
            yield return new WaitForSeconds(3f);
            failedText.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            StartCoroutine(CheckForWin());

        }
    }
}
