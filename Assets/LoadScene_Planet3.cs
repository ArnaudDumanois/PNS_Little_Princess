using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene_Planete3 : MonoBehaviour
{
    public string sceneToLoad = "NomDeVotreScene"; 

    // Fonction appelée au démarrage du script
    void Start()
    {
        StartCoroutine(LoadSceneAfterDelay());
    }
    
    IEnumerator LoadSceneAfterDelay()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(sceneToLoad);
    }
}