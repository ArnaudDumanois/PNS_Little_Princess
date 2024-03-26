using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class ButtonClickHandler : MonoBehaviour
{
    public List<string> listeDialogue = new List<string>();
    public Camera[] cameras; 
    public int dialogueEtape = 0; 
    public Button buttonChoice1; 
    public Button buttonChoice2; 
    public Button buttonPass; 
    public TMP_Text phraseMacron;
    public Canvas canvasMacron;
    public TMP_Text textButton1;
    public TMP_Text textButton2;
    
    
    public AudioSource audioSource; 

    public AudioClip audioClipDialogue1;
    public AudioClip audioClipDialogue2;
    public AudioClip audioClipDialogue3;
    public AudioClip audioClipDialogue4;
    public AudioClip audioClipDialogue5;
    public AudioClip audioClipDialogue6;
    

    void Awake()
    {
        
        cameras[0].gameObject.SetActive(true);
        cameras[1].gameObject.SetActive(false);
        cameras[2].gameObject.SetActive(false);
        canvasMacron.gameObject.SetActive(false);
        buttonChoice1.gameObject.SetActive(false);
        buttonChoice2.gameObject.SetActive(false);
        buttonPass.gameObject.SetActive(false);
        InitializeDialogue();
        
        
        buttonChoice1.onClick.AddListener(Choice1Clicked);
        buttonChoice2.onClick.AddListener(Choice2Clicked);
        buttonPass.onClick.AddListener(PassClicked);
    }
    
    public void OnClickButton()
    {
        Debug.Log("On a activé l'intéraction avec Macron");
        cameras[0].gameObject.SetActive(false);
        cameras[1].gameObject.SetActive(true);
        canvasMacron.gameObject.SetActive(true);
        dialogueEtape = 1;
        DisplayDialogue(); 
    }

    
    private void InitializeDialogue()
    {
        listeDialogue.Add("Bonjour, je suis Emmanuel Macron! Le vrai!");
        listeDialogue.Add("Que viens-tu faire ?");
        listeDialogue.Add("Aurevoir !");
        listeDialogue.Add("Oh! Ce sont les gilets jaunes qui ont tes bonbons !");
        listeDialogue.Add("Affronte-les dans une course pour les battre!");
        listeDialogue.Add("Bonne chance ! N'hésite pas à utiliser des LBD !");
    }

    
    private void DisplayDialogue()
    {
        if (dialogueEtape == 1)
        {
            phraseMacron.text = listeDialogue[0];
            buttonPass.gameObject.SetActive(true);
            
            audioSource.clip = audioClipDialogue1; 
            audioSource.Play();
            
        } else if (dialogueEtape == 2)
        {
            phraseMacron.text = listeDialogue[1];
            buttonPass.gameObject.SetActive(false);
            textButton1.text = "Je souhaite récupérer le bonbon magique !";
            textButton2.text = "Rien. Aurevoir";
            buttonChoice1.gameObject.SetActive(true);
            buttonChoice2.gameObject.SetActive(true);
            
            audioSource.clip = audioClipDialogue2; 
            audioSource.Play();
        } else if (dialogueEtape == 3)
        {
            phraseMacron.text = listeDialogue[3];
            buttonPass.gameObject.SetActive(true);
            buttonChoice1.gameObject.SetActive(false);
            buttonChoice2.gameObject.SetActive(false);
            
            audioSource.clip = audioClipDialogue4; 
            audioSource.Play();
        } else if (dialogueEtape == 4)
        {
            phraseMacron.text = listeDialogue[4];
            buttonPass.gameObject.SetActive(false);
            textButton1.text = "D'accord je suis partante!";
            textButton2.text = "Je ne suis pas motivée, aurevoir";
            buttonChoice1.gameObject.SetActive(true);
            buttonChoice2.gameObject.SetActive(true);
            
            audioSource.clip = audioClipDialogue5; 
            audioSource.Play();
        } else if (dialogueEtape == 5)
        {
            audioSource.clip = audioClipDialogue6; 
            audioSource.Play();
            //on doit mettre un sleep ou un truc dans le genre t'as capté
            Debug.Log("ON DOIT LANCER LA COURSE");
            cameras[0].gameObject.SetActive(false);
            cameras[1].gameObject.SetActive(false);
            cameras[2].gameObject.SetActive(true);
        }
    }

    private void PassClicked()
    {
        dialogueEtape++;
        DisplayDialogue();
    }

    private void Choice1Clicked()
    {
        dialogueEtape++;
        DisplayDialogue();
    }

    private void Choice2Clicked()
    {
        audioSource.clip = audioClipDialogue3; 
        audioSource.Play();
        dialogueEtape = 0;
        cameras[0].gameObject.SetActive(true);
        cameras[1].gameObject.SetActive(false);
        canvasMacron.gameObject.SetActive(false);
        buttonChoice1.gameObject.SetActive(false);
        buttonChoice2.gameObject.SetActive(false);
        buttonPass.gameObject.SetActive(false);
    }
}
