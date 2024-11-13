using UnityEngine;
using UnityEngine.UI;

public class CarSelector : MonoBehaviour
{
    [SerializeField] private Button previousButton;
    [SerializeField] private Button nextButton;
    [SerializeField] private GameObject[] carModels; // Tableau de modèles de voitures
    private int currentCar;

    private void Awake()
    {
        // Charger le modèle de voiture sauvegardé au démarrage du jeu
        LoadSelectedCar();

        // Vérifie si des modèles de voitures sont assignés dans le tableau
        if (carModels.Length > 0)
        {
            SelectCar(currentCar); // Initialise avec la voiture chargée
        }
        else
        {
            Debug.LogWarning("Aucun modèle de voiture n'est assigné dans le tableau carModels.");
        }
    }

    public void ChangeCar(int _change)
    {
        currentCar += _change;
        currentCar = Mathf.Clamp(currentCar, 0, carModels.Length - 1); // Limite l'index pour éviter les erreurs
        Debug.Log("ChangeCar called with change: " + _change + ", new currentCar: " + currentCar);
        SelectCar(currentCar);

        // Sauvegarde le modèle de voiture sélectionné
        SaveSelectedCar();
    }

    private void SelectCar(int _index)
    {
        Debug.Log("SelectCar called with index: " + _index);
        previousButton.interactable = (_index != 0);
        nextButton.interactable = (_index != carModels.Length - 1);

        for (int i = 0; i < carModels.Length; i++)
        {
            carModels[i].SetActive(i == _index);
        }
    }

    // Rendre cette méthode publique pour qu'elle soit accessible dans l'Inspector
    public void SaveSelectedCar()
    {
        // Sauvegarde l'index de la voiture sélectionnée
        PlayerPrefs.SetInt("SelectedCar", currentCar);
        PlayerPrefs.Save(); // Sauvegarde les PlayerPrefs immédiatement
    }

    private void LoadSelectedCar()
    {
        // Charge l'index de la voiture sélectionnée si elle existe
        if (PlayerPrefs.HasKey("SelectedCar"))
        {
            currentCar = PlayerPrefs.GetInt("SelectedCar");
        }
        else
        {
            currentCar = 0; // Par défaut, la première voiture
        }
    }
}
