using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporte : MonoBehaviour
{
    public Transform target; // Référence à l'objet que la caméra doit suivre
    
    // on choisit la lumiere qu'on va reduire
    public Light planetLight;
    
    public Planete1_MusicController musicController;
    
    void OnTriggerEnter(Collider other)
    {
        Console.WriteLine("Collision detected");
        if (other.CompareTag("Player"))
        {
            Console.WriteLine("Player detected");
            musicController.PlayTeleportMusic();
            other.transform.position = target.position;
            planetLight.intensity = 0.7f;
        }
    }
}
