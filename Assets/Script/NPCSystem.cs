using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSystem : MonoBehaviour
{
    bool player_detection = false;
    

    // Update is called once per frame
    void Update()
    {
        if (player_detection && Input.GetKeyDown(KeyCode.A))
        {
            print("Player Detected"); 
        }
        else
        {
            print("Player Not Detected"); 
        }
    }
    void OntriggerEnter(Collider other)
    {
        if(other.name == "Character1_Reference")
        {
            player_detection = true;
        }
    }
    void OntriggerExit(Collider other)
    {
            player_detection = false;
    }
}
