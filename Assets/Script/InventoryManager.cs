using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<Item> Items = new List<Item>();

    public Transform ItemContent;
    public GameObject InventoryItemPrefab;

    public Toggle EnableRemove;

    private void Awake()
    {
        Instance = this;
    }

    public void Add(Item item)
    {
        Items.Add(item);
    }

    public void Remove(Item item)
    {
        Items.Remove(item);
    }

    public void ListItems()
    {
        foreach (Transform item in ItemContent)
        {
            Destroy(item.gameObject);
        }
        foreach (var item in Items)
        {
            GameObject obj = Instantiate(InventoryItemPrefab, ItemContent);
            var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();
            itemIcon.sprite = item.icon;
            var removeButton = obj.transform.Find("RemoveButton").GetComponent<Button>();

            if (EnableRemove.isOn)
            {
                removeButton.gameObject.SetActive(true);
            }
            else
            {
                removeButton.gameObject.SetActive(false);
            }

            // Instantiate InventoryItemController dynamically
            InventoryItemController controller = obj.GetComponent<InventoryItemController>();
            if (controller == null)
            {
                Debug.LogError("InventoryItemController component not found on " + obj.name);
                continue;
            }
            controller.AddItem(item);
        }
    }

    public bool HasItem(string itemName) { 
        return Items.Exists(item => item.name == itemName); 
    }
    
    public void EnableItemsRemove()
    {
        if (EnableRemove.isOn)
        {
            foreach (Transform item in ItemContent)
            {
                item.Find("RemoveButton").gameObject.SetActive(true);
            }
        }
        else
        {
            foreach (Transform item in ItemContent)
            {
                item.Find("RemoveButton").gameObject.SetActive(false);
            }
        }
    }
}
