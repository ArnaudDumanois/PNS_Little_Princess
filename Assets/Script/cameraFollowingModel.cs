using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Référence à l'objet que la caméra doit suivre
    public float smoothSpeed = 0.125f; // Vitesse de suivi de la caméra
    public Vector3 offset; // Offset de position par rapport à la cible
    public float rotationSpeed = 5f; // Vitesse de rotation de la caméra

    void LateUpdate()
    {
        if (target != null)
        {
            // Calcul de la position désirée de la caméra
            Vector3 desiredPosition = target.position - offset;
            
            // Lissage du mouvement de la caméra
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition; // Déplacement de la caméra
            
            // Calcul de la rotation désirée de la caméra pour regarder vers le haut du personnage
            Vector3 directionToTarget = (target.position - transform.position).normalized;
            Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}