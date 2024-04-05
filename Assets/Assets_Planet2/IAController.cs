using UnityEngine;
using System.Collections.Generic;

public class AICarController : MonoBehaviour
{
    public Transform listCheckpoints;
    public float moveSpeed = 10f;
    public float rotationSpeed = 2f;
    public float maxSpeed = 20f;
    public float minSpeed = 5f;
    public float maxTurnDistance = 10f;
    public float minTurnDistance = 2f;

    private List<Transform> checkpoints = new List<Transform>();
    private int currentCheckpointIndex = 0;

    private bool isActivated = false;
    

    void Start()
    {
        if (listCheckpoints == null)
        {
            Debug.LogWarning("No ListCheckpoints object assigned to AI car.");
            return;
        }

        // Trouver tous les checkpoints enfants de ListCheckpoints et les ajouter à la liste
        foreach (Transform child in listCheckpoints)
        {
            checkpoints.Add(child);
        }
    }

    void FixedUpdate()
    {
        if (checkpoints.Count == 0)
        {
            Debug.LogWarning("No checkpoints assigned to AI car.");
            return;
        }
        
        Debug.Log($"ON VA AU CHECKPOINT {currentCheckpointIndex}");

        if (isActivated)
        {
            // Diriger la voiture vers le prochain checkpoint
            Vector3 targetDirection = checkpoints[currentCheckpointIndex].position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(-targetDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);

            // Calculer la distance jusqu'au prochain checkpoint
            float distanceToCheckpoint = Vector3.Distance(transform.position, checkpoints[currentCheckpointIndex].position);

            // Ajuster la vitesse en fonction de la distance au prochain checkpoint
            float adjustedSpeed = Mathf.Lerp(minSpeed, maxSpeed, Mathf.InverseLerp(minTurnDistance, maxTurnDistance, distanceToCheckpoint));
            transform.Translate(-Vector3.forward * adjustedSpeed * Time.deltaTime);

            // Si la voiture est suffisamment proche du checkpoint, passer au suivant
            if (distanceToCheckpoint < 5f)
            {
                currentCheckpointIndex = (currentCheckpointIndex + 1) % checkpoints.Count;
            }
        }
    }


    public void SetActive(bool value)
    {
        isActivated = value;
    }
}
