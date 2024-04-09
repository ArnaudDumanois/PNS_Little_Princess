using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class ConversationStarter : MonoBehaviour
{

    [SerializeField] private NPCConversation myConversation;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log(Input.GetKeyDown(KeyCode.X));
            if(Input.GetKeyDown(KeyCode.X)){
                Debug.Log("D key pressed");
                ConversationManager.Instance.StartConversation(myConversation);
            }
        }
    }      
}
