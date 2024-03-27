using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class cameraController3 : MonoBehaviour
{
    public Transform target; // Référence à l'objet que la caméra doit suivre
    public float smoothSpeed = 0.125f; // Vitesse de suivi de la caméra
    public float distance = 12f; // Distance entre la caméra et le personnage
    public float height = 5f; // Hauteur de la caméra par rapport au personnage

    void FixedUpdate()
    {
        if (target != null)
        {
            // // Calcul de la position désirée de la caméra basée sur la position du personnage et son vecteur forward
            Vector3 desiredPosition = target.position - target.forward * distance + Vector3.up * height;
            
            // Lissage du mouvement de la caméra
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition; // Déplacement de la caméra

            // Faites en sorte que la caméra regarde vers le personnage
            transform.LookAt(target);
            CheckCameraOcclusionAndCollision();
        }
    }

    public void CheckCameraOcclusionAndCollision()
    {
        RaycastHit hit;
        Vector3 trueTargetPosition = target.position - Vector3.up; // Slightly below the target to avoid occlusion by the target itself
        Vector3 direction = transform.position - trueTargetPosition;
        float distanceToTarget = direction.magnitude;

        // Cast a ray from the target towards the camera's desired position
        if (Physics.Raycast(trueTargetPosition, direction, out hit, distanceToTarget))
        {
            // If the ray hits something
            transform.position = hit.point; // Move the camera to the point of collision
        }
    }
}