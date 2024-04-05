using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class FinalInteractionScript : MonoBehaviour
{
    public Camera cameraMacron;
    public Camera cameraVoiture;
    
    public Canvas canvasMacron;
    public TMP_Text phraseMacron;
    public Button buttonChoice1; 
    public Button buttonChoice2;
    public Button buttonPass;

    private int dialogueNumber = 1;

    public Canvas finalCanvas;
    public AudioSource sourceAudio;
    public AudioClip succesSound;


    public AudioSource sourceAudioMacron;
    public AudioClip soundMacron1;
    public AudioClip soundMacron2;

    private void Awake()
    {
        finalCanvas.gameObject.SetActive(false);
    }


    public void activateFinalScript()
    {
        Vector3 nouvellePosition = new Vector3(-37f, 3.26f, 62.5f); // Par exemple, définir la position (0, 3, 0)
        transform.position = nouvellePosition;
        cameraVoiture.gameObject.SetActive(false);
        cameraMacron.gameObject.SetActive(true);
        buttonPass.onClick.AddListener(PassClicked);
        
        showDialogue();
        
        Debug.Log("LANCEMENT DU DERNIER SCRIPT D'INTERACTION");
    }


    void showDialogue()
    {
        canvasMacron.gameObject.SetActive(true);
        buttonPass.gameObject.SetActive(true);
        buttonChoice1.gameObject.SetActive(false);
        buttonChoice2.gameObject.SetActive(false);
        if (dialogueNumber == 1)
        {
            phraseMacron.text = "Bravo tu as été excellente !";
            sourceAudioMacron.clip = soundMacron1;
            sourceAudioMacron.Play();
        } else if (dialogueNumber == 2)
        {
            phraseMacron.text = "Prend ton bonbon, tu l'as mérité !";
            sourceAudioMacron.clip = soundMacron2;
            sourceAudioMacron.Play();
        } else if (dialogueNumber == 3)
        {
            canvasMacron.gameObject.SetActive(false);
            finalCanvas.gameObject.SetActive(true);
            sourceAudio.clip = succesSound; 
            sourceAudio.Play();
        }
    }
    
    private void PassClicked()
    {
        dialogueNumber++;
        showDialogue();
    }
}
