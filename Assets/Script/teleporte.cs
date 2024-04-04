using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporte : MonoBehaviour
{
    public Transform target; // Référence à l'objet que la caméra doit suivre
    
    void OnTriggerEnter(Collider other)
    {
        Console.WriteLine("Collision detected");
        if (other.CompareTag("Player"))
        {
            Console.WriteLine("Player detected");
            other.transform.position = target.position;
        }
    }
}
