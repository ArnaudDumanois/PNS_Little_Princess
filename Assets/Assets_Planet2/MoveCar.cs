using System;
using UnityEngine;
using System.Collections;
using TMPro;
using System.Collections.Generic;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    private bool isActive = false;
    private bool isMusicActive = false;
    private bool canMove = true; // Ajout d'un indicateur pour savoir si la voiture peut bouger
	private List<String> checkpoints = new List<String>();

    public AudioSource audioSource;

    public List<AudioClip> radioMusic = new List<AudioClip>();
    
    public Canvas canvaReadyGo;
    public TMP_Text textPrintReadyGo;

    private int nbLapsDone = 0;

    private bool isRaceFinished = false;
    
    public AICarController controllerIA;

    public FinalInteractionScript finalInteractionScript;

    private int currentMusicPlayed = 0;

    public Canvas radio;
    public TMP_Text currentMusic;
    public Button skipMusic;
    

    public void SetActive(bool value)
    {
        isActive = value;
    }

    void Awake()
    {
        canvaReadyGo.gameObject.SetActive(false);
        radio.gameObject.SetActive(false);
        skipMusic.onClick.AddListener(skipMusicFunction);
    }

    void skipMusicFunction()
    {
        currentMusicPlayed++;
        currentMusicPlayed = currentMusicPlayed % radioMusic.Count;
        currentMusic.text = "Current Music : " + radioMusic[currentMusicPlayed].name;
        audioSource.clip = radioMusic[currentMusicPlayed];
        audioSource.Play();
    }

    void FixedUpdate()
    {
        if (isActive && canMove) // Vérification si la voiture peut bouger
        {
            activateMusic();
            float moveSpeed = 45f;
            float rotationSpeed = 100f;

            float moveInput = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime * -1;
            transform.Translate(0f, 0f, moveInput);

            float rotationInput = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
            transform.Rotate(0f, rotationInput, 0f);
        }
    }

	void OnTriggerEnter(Collider other)
    {
		Debug.Log(other.gameObject.name);
        checkpoints.Add(other.gameObject.name);

		if (HasTourFinished(checkpoints))
        {
            Debug.Log("On a fini le tour !");
            nbLapsDone += 1;
            StartCoroutine(DisplayTourCount());
            checkpoints.Clear();
            if (nbLapsDone == 2)
            {
                endCourse();
                isRaceFinished = true;
            }
        }
    }

    void LaunchFinalInteraction()
    {
        finalInteractionScript.activateFinalScript();
    }

    void endCourse()
    {
        radio.gameObject.SetActive(false);
        Debug.Log("Fin de la course)");
        StartCoroutine(DisplayEndCourse());
    }
    
    IEnumerator DisplayEndCourse()
    {
        canvaReadyGo.gameObject.SetActive(true);
        textPrintReadyGo.text = "Fin de la course !";
        yield return new WaitForSeconds(4);
        canvaReadyGo.gameObject.SetActive(false);
        audioSource.Stop();
        LaunchFinalInteraction();
        canMove = false;
    }
    
    
    
    IEnumerator DisplayTourCount()
    {
        canvaReadyGo.gameObject.SetActive(true);
        textPrintReadyGo.text = "Tour fini " + nbLapsDone + "/2";
        yield return new WaitForSeconds(5);
        canvaReadyGo.gameObject.SetActive(false);
    }

    void activateMusic()
    {
        if (!isMusicActive)
        {
            radio.gameObject.SetActive(true);
            currentMusic.text = "Current Music : " + radioMusic[currentMusicPlayed].name;
            audioSource.clip = radioMusic[currentMusicPlayed];
            audioSource.Play();
            isMusicActive = true;
            StartCoroutine(DisableMovementForSeconds(10f)); 
            Debug.Log("On active la musique");
        }
		
    }

    // Coroutine pour désactiver le mouvement pendant un certain nombre de secondes
    IEnumerator DisableMovementForSeconds(float seconds)
    {
        canMove = false; 
        canvaReadyGo.gameObject.SetActive(true); 
        textPrintReadyGo.text = "Êtes-vous prêts ?";
        yield return new WaitForSeconds(5); 
        textPrintReadyGo.text = "Attention ça va démarrer !";
        yield return new WaitForSeconds(5);
        canMove = true; 
        controllerIA.SetActive(true);
        canvaReadyGo.gameObject.SetActive(false); 
    }

	bool HasTourFinished(List<String> list)
    {
        HashSet<String> set = new HashSet<String>(list);
        return set.Count == 39 && list[list.Count-1] == "CheckPoint1";
    }
}
