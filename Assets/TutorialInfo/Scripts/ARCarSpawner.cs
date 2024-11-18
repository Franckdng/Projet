using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.Collections.Generic;

public class ARCarSpawner : MonoBehaviour
{
    public GameObject carPrefab;  // La voiture 3D que tu veux faire appara�tre
    private ARRaycastManager raycastManager;
    private GameObject spawnedCar;
    private bool carSpawned = false;

    void Start()
    {
        // R�cup�re le ARRaycastManager pour d�tecter les surfaces planes
        raycastManager = GetComponent<ARRaycastManager>();
    }

    void Update()
    {
        // Si la voiture n'a pas encore �t� spawn�e et qu'il y a une surface plane d�tect�e
        if (!carSpawned)
        {
            TrySpawnCar();
        }
    }

    // M�thode pour essayer de faire appara�tre la voiture
    void TrySpawnCar()
    {
        // Liste des surfaces d�tect�es
        List<ARRaycastHit> hits = new List<ARRaycastHit>();

        // Si un rayon partant du centre de l'�cran touche une surface plane
        if (raycastManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.PlaneWithinPolygon))
        {
            // Si une surface est d�tect�e
            Pose hitPose = hits[0].pose;

            // Si la voiture n'est pas encore spawn�e
            if (spawnedCar == null)
            {
                // Cr�er la voiture � la position d�tect�e
                spawnedCar = Instantiate(carPrefab, hitPose.position, hitPose.rotation);
                carSpawned = true;  // Marquer la voiture comme spawn�e
            }
        }
    }
}
