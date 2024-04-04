using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Référence à l'objet que la caméra doit suivre
    public float smoothSpeed = 1f; // Vitesse de suivi de la caméra
    public float distance = -14f; // Distance entre la caméra et le personnage
    public float height = 8f; // Hauteur de la caméra par rapport au personnage

    void FixedUpdate()
    {
        if (target != null)
        {
            // Calcul de la position désirée de la caméra basée sur la position du personnage et son vecteur forward
            Vector3 desiredPosition = target.position - target.forward * distance + Vector3.up * height;

            // Lissage du mouvement de la caméra
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition; // Déplacement de la caméra

            // Faites en sorte que la caméra regarde vers le personnage
            transform.LookAt(target);
        }
    }
}