using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class InteractionPlayer : MonoBehaviour
{
    public GameObject macronModel;
    public float interactionDistance = 2f;
    public Canvas interactionCanvas;
    public Vector3 teleportPosition = new Vector3(-37f, 3.26f, 26.9f);

    void Update()
    {
        if (Vector3.Distance(transform.position, macronModel.transform.position) < interactionDistance)
        {
            interactionCanvas.gameObject.SetActive(true);
            
            if (Input.GetKeyDown(KeyCode.A))
            {
                FadeToBlackAndTeleport();
            }
        }
        else
        {
            interactionCanvas.gameObject.SetActive(false);
        }
    }

    void FadeToBlackAndTeleport()
    {
        Debug.Log("AAAAAAAAAAA");
    }
}
