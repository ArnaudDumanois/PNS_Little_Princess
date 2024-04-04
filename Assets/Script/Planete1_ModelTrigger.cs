using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planete1_ModelTrigger : MonoBehaviour
{
    public Planete1_UI ui; // Référence au script Planete1_UI
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ui.UpdateText(); // Met à jour le texte à afficher
            gameObject.SetActive(false); // Désactive le modèle
        }
    }
}
