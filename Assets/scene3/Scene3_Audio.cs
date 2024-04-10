using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene3_Audio : MonoBehaviour
{
    // Référence à l'Audio Source
    private AudioSource audioSource;

    private void Start()
    {
        // Récupérer le composant Audio Source
        audioSource = GetComponent<AudioSource>();

        // Démarrer la lecture de la musique
        audioSource.Play();
    }
}
