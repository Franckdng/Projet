using UnityEngine;
using UnityEngine.UI;

public class CarSelector : MonoBehaviour
{
    public GameObject[] carModels; // Liste des modèles de voitures
    private int currentIndex = 0;  // Index du modèle actuel

    // Références aux boutons de navigation
    public Button leftArrowButton;
    public Button rightArrowButton;

    void Start()
    {
        // Vérifiez si les boutons sont bien assignés
        if (leftArrowButton != null && rightArrowButton != null)
        {
            leftArrowButton.onClick.AddListener(ShowPreviousCar);
            rightArrowButton.onClick.AddListener(ShowNextCar);
        }
        else
        {
            Debug.LogError("Les boutons ne sont pas assignés dans l'Inspector !");
        }

        // Afficher le premier modèle au début
        ShowCar(currentIndex);
    }

    // Afficher le modèle de voiture selon l'index
    void ShowCar(int index)
    {
        // Désactiver tous les modèles
        foreach (var car in carModels)
        {
            car.SetActive(false);
        }

        // Activer le modèle sélectionné
        if (carModels.Length > 0 && index >= 0 && index < carModels.Length)
        {
            carModels[index].SetActive(true);
        }
        else
        {
            Debug.LogError("Index du modèle de voiture invalide : " + index);
        }
    }

    // Afficher le modèle précédent
    public void ShowPreviousCar()
    {
        Debug.Log("Flèche gauche cliquée !");  // Message de débogage
        currentIndex = (currentIndex - 1 + carModels.Length) % carModels.Length;
        ShowCar(currentIndex);
    }

    // Afficher le modèle suivant
    public void ShowNextCar()
    {
        Debug.Log("Flèche droite cliquée !");  // Message de débogage
        currentIndex = (currentIndex + 1) % carModels.Length;
        ShowCar(currentIndex);
    }
}
