using UnityEngine;
using UnityEngine.UI;

public class CarSelector : MonoBehaviour
{
    [SerializeField] private Button previousButton;
    [SerializeField] private Button nextButton;
    [SerializeField] private GameObject[] carModels; // Tableau de mod�les de voitures
    private int currentCar;

    private void Awake()
    {
        // Charger le mod�le de voiture sauvegard� au d�marrage du jeu
        LoadSelectedCar();

        // V�rifie si des mod�les de voitures sont assign�s dans le tableau
        if (carModels.Length > 0)
        {
            SelectCar(currentCar); // Initialise avec la voiture charg�e
        }
        else
        {
            Debug.LogWarning("Aucun mod�le de voiture n'est assign� dans le tableau carModels.");
        }
    }

    public void ChangeCar(int _change)
    {
        currentCar += _change;
        currentCar = Mathf.Clamp(currentCar, 0, carModels.Length - 1); // Limite l'index pour �viter les erreurs
        Debug.Log("ChangeCar called with change: " + _change + ", new currentCar: " + currentCar);
        SelectCar(currentCar);

        // Sauvegarde le mod�le de voiture s�lectionn�
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

    // Rendre cette m�thode publique pour qu'elle soit accessible dans l'Inspector
    public void SaveSelectedCar()
    {
        // Sauvegarde l'index de la voiture s�lectionn�e
        PlayerPrefs.SetInt("SelectedCar", currentCar);
        PlayerPrefs.Save(); // Sauvegarde les PlayerPrefs imm�diatement
    }

    private void LoadSelectedCar()
    {
        // Charge l'index de la voiture s�lectionn�e si elle existe
        if (PlayerPrefs.HasKey("SelectedCar"))
        {
            currentCar = PlayerPrefs.GetInt("SelectedCar");
        }
        else
        {
            currentCar = 0; // Par d�faut, la premi�re voiture
        }
    }
}
