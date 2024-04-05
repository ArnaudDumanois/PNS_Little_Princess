using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Planete1_UI : MonoBehaviour
{
    public TextMeshProUGUI text; // Référence au texte à afficher
    private int visitedModel = 0; // nombre de modèles visités
    
    public Camera mainCamera; // Référence à la caméra principale
    public Camera endCamera; // Référence à la caméra de fin


    public void Start()
    {
        endCamera.gameObject.SetActive(false); // Désactive la caméra de fin
    }

    // met a jour le texte à afficher
    public void UpdateText()
    {
        visitedModel++;
        text.text = "Modèles visités " + visitedModel.ToString() + "/4";
        
        if (visitedModel == 4)
        {
            text.text = "Vous avez visité tous les modèles !";
            endCamera.gameObject.SetActive(true); // Active la caméra
            mainCamera.gameObject.SetActive(false); // Désactive la caméra principale
            Invoke("DisableCamera", 2f);
        }
    }
    
    // désactive la caméra
    private void DisableCamera()
    {
        endCamera.gameObject.SetActive(false);
        mainCamera.gameObject.SetActive(true);
    }
}
