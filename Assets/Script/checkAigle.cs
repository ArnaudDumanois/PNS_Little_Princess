using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkAigle : MonoBehaviour
{
    // Reference to the inventory manager
    public InventoryManager inventoryManager;

    bool hasItem = false;


    // Update is called once per frame
    public bool HasItemAigle()
    {
        // Check if the item "axe" exists in the inventory manager
        if (inventoryManager.HasItem("axe"))
        {
            hasItem = true;
            Debug.Log("The item 'axe' exists in the inventory manager.");
        }
        else
        {
            Debug.Log("The item 'axe' does not exist in the inventory manager.");
        }
        return hasItem;
    }
}
