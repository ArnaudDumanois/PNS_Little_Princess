using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class ConversationStarter : MonoBehaviour
{
    [SerializeField] private NPCConversation myConversation;

    private bool conversationStarted = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !conversationStarted)
        {
            Debug.Log("Player entered trigger zone.");
            conversationStarted = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && conversationStarted)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                Debug.Log("X key pressed");
                ConversationManager.Instance.StartConversation(myConversation);
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
