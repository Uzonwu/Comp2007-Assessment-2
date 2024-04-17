using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class churchSign : MonoBehaviour, IInteractable
{
    public TextMeshProUGUI firstText;
    public TextMeshProUGUI secondText;


    public void OnInteract()
    {
        StartCoroutine(DisplayText());
    }

    IEnumerator DisplayText()
    {
        firstText.gameObject.SetActive(true);
        yield return new WaitForSeconds(3f); 
        firstText.gameObject.SetActive(false);

        secondText.gameObject.SetActive(true);
        yield return new WaitForSeconds(5f); 
        secondText.gameObject.SetActive(false);
    }
}
