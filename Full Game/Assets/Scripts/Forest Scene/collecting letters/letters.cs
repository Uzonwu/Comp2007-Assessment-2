using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class letters : MonoBehaviour, IInteractable
{
    public AudioSource pickupSound;
    public void OnInteract()
    {
        PlayerInventory playerInventory = FindObjectOfType<PlayerInventory>(); 
        if (playerInventory != null)
        {
            playerInventory.ItemsCollected(); 
            gameObject.SetActive(false);
            if (pickupSound != null)
            {
                pickupSound.Play();
            }
        }
    }
}
