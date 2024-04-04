using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class InteractionPlayer : MonoBehaviour
{
    public GameObject macronModel;
    public float interactionDistance = 2f;
    public Button interactionButton;
    public Vector3 teleportPosition = new Vector3(-37f, 3.26f, 26.9f);
    public bool shouldWeShowIt = true;

    void Update()
    {
        if (Vector3.Distance(transform.position, macronModel.transform.position) < interactionDistance && shouldWeShowIt)
        {
            interactionButton.gameObject.SetActive(true);
        }
        else
        {
            interactionButton.gameObject.SetActive(false);
        }
    }

    public void setShouldWeShowIt(bool value)
    {
        shouldWeShowIt = value;
    }
}
