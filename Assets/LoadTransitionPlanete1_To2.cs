using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadTransitionPlanete1_To2 : MonoBehaviour
{
    public Planete1_UI ui; // Référence au script Planete1_UI
    
    public string sceneToLoad = "NomDeVotreScene"; 

    private bool hasPickup = false; // Variable pour savoir si le joueur a ramassé l'objet
    
    // Fonction appelée au démarrage du script
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !hasPickup)
        {
            StartCoroutine(PickupSequence());
        }
    }
    
     
    IEnumerator PickupSequence()
    {
        // l'objet monte sur 2 secondes
        float timer = 0f;
        Vector3 initialPosition = transform.position;
        Vector3 targetPosition = initialPosition + Vector3.up * 2f;
        while (timer < 2f)
        {
            float t = timer / 2f;
            transform.position = Vector3.Lerp(initialPosition, targetPosition, t);
            timer += Time.deltaTime;
            yield return null;
        }
        
        // l'objet redescent sur 2 secondes et disparait petit a petit en redescendant
        timer = 0f;
        Vector3 initialScale = transform.localScale;
        Vector3 targetScale = Vector3.zero;
        while (timer < 2f)
        {
            float t = timer / 2f;
            transform.position = Vector3.Lerp(targetPosition, initialPosition, t);
            transform.localScale = Vector3.Lerp(initialScale, targetScale, t);
            timer += Time.deltaTime;
            yield return null;
        }
        ui.EndText();
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(sceneToLoad);
    }
}
