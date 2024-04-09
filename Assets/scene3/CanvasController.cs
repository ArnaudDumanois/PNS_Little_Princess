using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CanvasController : MonoBehaviour
{
    public GameObject canvas;

    void Start()
    {
        // Ensure the canvas is initially enabled
        canvas.SetActive(false);
    }

    void OnTriggerEnter(Collider player){
        if(player.tag == "Player"){
            // Disable the canvas when the player enters the trigger
            canvas.SetActive(true);
            StartCoroutine("WaitForSec");
        }
    }

    IEnumerator WaitForSec(){
        yield return new WaitForSeconds(10);
        Destroy(canvas);
        Destroy(gameObject);
    }
}
