using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;
using Unity.VisualScripting;

public class ConversationStarterOiseau : MonoBehaviour
{
    [SerializeField] private NPCConversation myConversation;
    int hasItem = 0;

    private bool conversationStarted = false;
    public GameObject planetObject;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !conversationStarted)
        {
            Debug.Log("Player entered trigger zone.");
            conversationStarted = true;
        }
    }

    void Start() {
        planetObject.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && conversationStarted)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                Debug.Log("X key pressed");
                hasItem = InventoryManager.Instance.HasItem("glasses") ? 1 : 0;
                Debug.Log("hasItem: " + hasItem);
                ConversationManager.Instance.StartConversation(myConversation);
                ConversationManager.Instance.SetInt("hasItem", hasItem);
                if (hasItem == 1)
                {
                    planetObject.SetActive(true);
                }
                conversationStarted = false; // Resetting for potential future conversations
            }
            else
            {
                Debug.Log("X key not pressed");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player exited trigger zone.");
            conversationStarted = false; // Resetting if player exits before pressing X
        }
    }
}
