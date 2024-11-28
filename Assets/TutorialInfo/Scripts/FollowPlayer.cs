using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset = new Vector3(0, 3, -5);
    /*public float rotationDamping = 0.05f; // Contrôle l'ampleur du balancement
    private Quaternion targetRotation;*/
    public PlayerController playerController;
    public float followSpeed;      // Vitesse de suivi de la position
    public float rotationSpeed = 5f;    // Vitesse de suivi de la rotation
    public float distanceFactor = 0.05f;
    public float maxDistanceOffset = 0.1f;
    // Start is called before the first frame update
    private Vector3 velocity = Vector3.zero;
    public float maxFollowSpeed = 10f; // Max speed for camera follow

    void Start()
    {
        if (player == null)
        {
            Debug.LogError("La référence 'player' n'est pas assignée dans FollowPlayer.");
        }

        if (playerController == null)
        {
            Debug.LogError("La référence 'playerController' n'est pas assignée dans FollowPlayer.");
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {

       /* Vector3 dynamicOffset = offset + Vector3.back * Mathf.Clamp(playerController.speed * distanceFactor, 0, maxDistanceOffset);
        // Position cible en tenant compte de l'offset
        Vector3 targetPosition = player.transform.position + player.transform.rotation * dynamicOffset;
        followSpeed = playerController.speed /3f;
        if (followSpeed < 5) { followSpeed = 5; }
        // Lissage de la position (on interpole vers la position cible pour éviter un mouvement brusque)
        transform.position = Vector3.Lerp(transform.position, targetPosition, 8 * Time.deltaTime);
        //transform.position = player.transform.position + player.transform.rotation * dynamicOffset;

        // Calcul de la rotation cible pour garder la caméra derrière la voiture
        Quaternion targetRotation = Quaternion.LookRotation(player.transform.position - transform.position);

        // Lissage de la rotation (on interpole vers la rotation cible pour un suivi plus fluide)
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);*/
    }


    /*void LateUpdate()
    {
        // Calculer l'offset dynamique (ajuster distanceFactor et maxDistanceOffset si nécessaire)
        float offsetFactor = Mathf.Lerp(0, maxDistanceOffset, playerController.speed / 70);
        Vector3 dynamicOffset = offset + Vector3.back * offsetFactor;

        // Position cible avec l'offset
        Vector3 targetPosition = player.transform.position + player.transform.rotation * dynamicOffset;

        // Lissage de la position
        float smoothFactor = Mathf.Clamp01(followSpeed * Time.deltaTime);
        transform.position = targetPosition;

        // Calcul de la rotation cible
        Quaternion targetRotation = Quaternion.LookRotation(player.transform.position - transform.position);

        // Lissage de la rotation
        float smoothRotationFactor = Mathf.Clamp01(rotationSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Slerp(transform.rotation , targetRotation, smoothRotationFactor);
    }*/

}
