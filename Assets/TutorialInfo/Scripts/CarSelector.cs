using UnityEngine;
using UnityEngine.UI;

public class CarSelector : MonoBehaviour
{
    public GameObject[] carModels; // Liste des mod�les de voitures
    private int currentIndex = 0;  // Index du mod�le actuel

    // R�f�rences aux boutons de navigation
    public Button leftArrowButton;
    public Button rightArrowButton;

    void Start()
    {
        // V�rifiez si les boutons sont bien assign�s
        if (leftArrowButton != null && rightArrowButton != null)
        {
            leftArrowButton.onClick.AddListener(ShowPreviousCar);
            rightArrowButton.onClick.AddListener(ShowNextCar);
        }
        else
        {
            Debug.LogError("Les boutons ne sont pas assign�s dans l'Inspector !");
        }

        // Afficher le premier mod�le au d�but
        ShowCar(currentIndex);
    }

    // Afficher le mod�le de voiture selon l'index
    void ShowCar(int index)
    {
        // D�sactiver tous les mod�les
        foreach (var car in carModels)
        {
            car.SetActive(false);
        }

        // Activer le mod�le s�lectionn�
        if (carModels.Length > 0 && index >= 0 && index < carModels.Length)
        {
            carModels[index].SetActive(true);
        }
        else
        {
            Debug.LogError("Index du mod�le de voiture invalide : " + index);
        }
    }

    // Afficher le mod�le pr�c�dent
    public void ShowPreviousCar()
    {
        Debug.Log("Fl�che gauche cliqu�e !");  // Message de d�bogage
        currentIndex = (currentIndex - 1 + carModels.Length) % carModels.Length;
        ShowCar(currentIndex);
    }

    // Afficher le mod�le suivant
    public void ShowNextCar()
    {
        Debug.Log("Fl�che droite cliqu�e !");  // Message de d�bogage
        currentIndex = (currentIndex + 1) % carModels.Length;
        ShowCar(currentIndex);
    }
}
