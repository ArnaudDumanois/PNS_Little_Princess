using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<Item> Items = new List<Item>();
    public string sceneToLoad = "NomDeVotreScene"; 
    private bool hasPickup = false;

    private bool cameraMain = false;

    public Transform ItemContent;
    public GameObject InventoryItemPrefab;
    public GameObject planetObject;

    public Toggle EnableRemove;
    public Camera endCamera;
    public Camera mainCamera;

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
    
    void Update()
    {
        int count = 0;
        foreach (Item item in Items)
        {
            if (item.name == "finalcandy")
            {
                if (!hasPickup)
                {
                    StartCoroutine(LoadSceneAfterDelay());
                    hasPickup = true;
                }
            }
            if (item.name == "candy")
            {
                count++;
            }
        }
        if (count == 3 && !cameraMain)
        {
            cameraMain = true;
            endCamera.gameObject.SetActive(true);
            mainCamera.gameObject.SetActive(false);
            planetObject.SetActive(true);
            Invoke("DisableCamera", 2f);
        }

    }
    IEnumerator LoadSceneAfterDelay()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(sceneToLoad);
    }

    private void DisableCamera()
    {
        endCamera.gameObject.SetActive(false);
        mainCamera.gameObject.SetActive(true);
    }

    public bool HasItem(string itemName) { 
        return Items.Exists(item => item.name == itemName); 
    }

    public void RemoveItem(string itemName)
    {
        Item itemToRemove = Items.Find(item => item.name == itemName);
        if (itemToRemove != null)
        {
            Items.Remove(itemToRemove);
        }
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
    void Start()
    {
        planetObject.SetActive(false);
        endCamera.gameObject.SetActive(false);
    }
}
