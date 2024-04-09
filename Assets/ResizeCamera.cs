using UnityEngine;

public class ResizeCamera : MonoBehaviour
{
    void Start()
    {
        Camera.main.orthographicSize = Screen.height / 2f;
    }
}