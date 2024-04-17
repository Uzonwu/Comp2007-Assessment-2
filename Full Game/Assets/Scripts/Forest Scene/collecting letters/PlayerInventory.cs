using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    public int NumberOfItems {  get; private set; }
    public UnityEvent<PlayerInventory> OnItemsCollected;

    public void ItemsCollected()
    {
        NumberOfItems++;
        OnItemsCollected.Invoke(this);
    }
}
