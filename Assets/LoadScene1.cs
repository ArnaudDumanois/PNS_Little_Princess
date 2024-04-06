using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene1 : MonoBehaviour
{
    public string sceneName = "Planete1"; // Nom de la scène à charger

    // Fonction appelée lors du clic sur le bouton
    public void LoadSceneOnClick()
    {
        // Charger la scène avec le nom spécifié
        SceneManager.LoadScene(sceneName);
    }
}
