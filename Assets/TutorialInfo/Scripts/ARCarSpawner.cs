using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.Collections.Generic;

public class ARCarSpawner : MonoBehaviour
{
    public GameObject carPrefab;  // La voiture 3D que tu veux faire apparaître
    private ARRaycastManager raycastManager;
    private GameObject spawnedCar;
    private bool carSpawned = false;

    void Start()
    {
        // Récupère le ARRaycastManager pour détecter les surfaces planes
        raycastManager = GetComponent<ARRaycastManager>();
    }

    void Update()
    {
        // Si la voiture n'a pas encore été spawnée et qu'il y a une surface plane détectée
        if (!carSpawned)
        {
            TrySpawnCar();
        }
    }

    // Méthode pour essayer de faire apparaître la voiture
    void TrySpawnCar()
    {
        // Liste des surfaces détectées
        List<ARRaycastHit> hits = new List<ARRaycastHit>();

        // Si un rayon partant du centre de l'écran touche une surface plane
        if (raycastManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.PlaneWithinPolygon))
        {
            // Si une surface est détectée
            Pose hitPose = hits[0].pose;

            // Si la voiture n'est pas encore spawnée
            if (spawnedCar == null)
            {
                // Créer la voiture à la position détectée
                spawnedCar = Instantiate(carPrefab, hitPose.position, hitPose.rotation);
                carSpawned = true;  // Marquer la voiture comme spawnée
            }
        }
    }
}
