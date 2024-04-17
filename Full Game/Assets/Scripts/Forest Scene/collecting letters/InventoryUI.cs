using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    private TextMeshProUGUI letterText;

    void Start()
    {
        letterText = GetComponent<TextMeshProUGUI>();
        
    }

    public void UpdateLetterText(PlayerInventory playerInventory)
    {
        letterText.text = playerInventory.NumberOfItems.ToString();
    }

}
