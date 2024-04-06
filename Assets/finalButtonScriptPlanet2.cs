using UnityEngine;
using UnityEngine.SceneManagement;

public class finalButtonScriptPlanet2 : MonoBehaviour
{
    public string sceneName = "Planete1"; // Nom de la scène à charger
    
    public void LoadSceneOnClick()
    {
        SceneManager.LoadScene(sceneName);
    }
}