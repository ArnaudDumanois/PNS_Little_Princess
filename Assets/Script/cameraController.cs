using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    public Transform target; // Référence à l'objet que la caméra doit suivre
    public float smoothSpeed = 0.125f; // Vitesse de suivi de la caméra
    public float distance = 12f; // Distance entre la caméra et le personnage
    public float height = 5f; // Hauteur de la caméra par rapport au personnage
    
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
            CheckCameraOcclusionAndCollision(transform);
        }
    }

    public void CheckCameraOcclusionAndCollision(Transform cam)
    {
        RaycastHit hit = new RaycastHit();
        Vector3 trueTargetPosition = target.transform.position - new Vector3(0, -1, 0);
        // Cast the line to check for occlusion
        if (Physics.Linecast(trueTargetPosition, cam.transform.position, out hit))
        {
            // If the line has hit something
            if (hit.transform.tag != "Player")
            {
                // Get the normal of the hit point
                Vector3 hitNormal = hit.normal;
                // Get the point of contact
                Vector3 hitPoint = hit.point;
                // Set the new position of the camera
                cam.transform.position = new Vector3(hitPoint.x + hitNormal.x * 0.5f, hitPoint.y + hitNormal.y * 0.5f, hitPoint.z + hitNormal.z * 0.5f);
            }
        }
        else
        {
            cam.transform.position = Vector3.Lerp(cam.transform.position, trueTargetPosition, Time.deltaTime * 5);
        }
    }
}