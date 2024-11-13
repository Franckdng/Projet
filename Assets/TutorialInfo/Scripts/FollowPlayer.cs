using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset = new Vector3(0, 3, -5);
    public float rotationDamping = 0.05f; // Contrôle l'ampleur du balancement
    private Quaternion targetRotation;
    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // Position de la caméra avec offset en fonction de la rotation de la voiture
        transform.position = player.transform.position + player.transform.rotation * offset;

        // Calcule la rotation cible de la caméra
        targetRotation = Quaternion.LookRotation(player.transform.position - transform.position) * Quaternion.Euler(-17, 0, 0);

        // Ajoute un balancement vers la droite/gauche en fonction de la rotation de la voiture
        float horizontalInput = Input.GetAxis("Horizontal"); // "Horizontal" est la touche gauche/droite dans Unity
        float swayAmount = horizontalInput * rotationDamping; // Le facteur de balancement

        // Applique le balancement à la rotation cible
        targetRotation *= Quaternion.Euler(0, swayAmount * 30f, 0);

        // Interpole vers la rotation cible pour plus de fluidité
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 3);
    }
}
