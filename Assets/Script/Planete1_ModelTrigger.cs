using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planete1_ModelTrigger : MonoBehaviour
{
    public Planete1_UI ui; // Référence au script Planete1_UI
    
    public float disableDelay = 7f; // Délai avant de désactiver le modèle
    public float shrinkDuration = 2f; // Durée de l'animation de rétrécissement
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ui.UpdateText(); // Met à jour le texte à afficher
            StartCoroutine(DisableAfterDelay()); // Désactive le modèle après un délai
        }
    }
    
    IEnumerator DisableAfterDelay()
    {
        yield return new WaitForSeconds(disableDelay);
        
        float timer = 0f;
        Vector3 initialScale = transform.localScale;
        Vector3 targetScale = Vector3.zero;
        while (timer < shrinkDuration)
        {
            float t = timer / shrinkDuration;
            transform.localScale = Vector3.Lerp(initialScale, targetScale, t);
            timer += Time.deltaTime;
            yield return null;
        }
        transform.localScale = targetScale;
        gameObject.SetActive(false);
    }
}
