using UnityEngine;
using System.Collections;
using TMPro;
using System.Collections.Generic;

public class Controller : MonoBehaviour
{
    private bool isActive = false;
    private bool isMusicActive = false;
    private bool canMove = true; // Ajout d'un indicateur pour savoir si la voiture peut bouger
	private List<char> checkpoints = new List<char>();

    public AudioSource audioSource;
    public AudioClip musicGasGasGas;
    
    public Canvas canvaReadyGo;
    public TMP_Text textPrintReadyGo;

    public void SetActive(bool value)
    {
        isActive = value;
    }

    void Awake()
    {
        canvaReadyGo.gameObject.SetActive(false);
    }

    void FixedUpdate()
    {
        if (isActive && canMove) // Vérification si la voiture peut bouger
        {
            activateMusic();
            float moveSpeed = 25f;
            float rotationSpeed = 50f;

            float moveInput = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime * -1;
            transform.Translate(0f, 0f, moveInput);

            float rotationInput = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
            transform.Rotate(0f, rotationInput, 0f);
        }
    }

	void OnTriggerEnter(Collider other)
    {
		Debug.Log(other.gameObject.name);
		char lastChar = other.gameObject.name[other.gameObject.name.Length - 1];
        checkpoints.Add(lastChar);

		if (HasTourFinished(checkpoints))
        {
            Debug.Log("On a fini le tour !");
			//checkpoints.clear();
			
        }
    }

    void activateMusic()
    {
        if (!isMusicActive)
        {
            audioSource.clip = musicGasGasGas;
            audioSource.Play();
            isMusicActive = true;
            StartCoroutine(DisableMovementForSeconds(10f)); // Appel de la coroutine pour désactiver le mouvement
            Debug.Log("On active la musique");
        } else {
			canvaReadyGo.gameObject.SetActive(false);
		}
		
    }

    // Coroutine pour désactiver le mouvement pendant un certain nombre de secondes
    IEnumerator DisableMovementForSeconds(float seconds)
    {
        canMove = false; // Désactiver le mouvement
        canvaReadyGo.gameObject.SetActive(true); // Correction ici
        textPrintReadyGo.text = "Êtes-vous prêts ?";
        yield return new WaitForSeconds(5); // Attendre pendant le délai spécifié
        textPrintReadyGo.text = "Attention ça va démarrer !";
        yield return new WaitForSeconds(5);
        canMove = true; // Réactiver le mouvement après le délai
    }

	bool HasTourFinished(List<char> list)
    {
        HashSet<char> set = new HashSet<char>(list);
        return set.Count == 7;
    }
}
