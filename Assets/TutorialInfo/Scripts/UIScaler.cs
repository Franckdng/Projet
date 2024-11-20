using UnityEngine;
using UnityEngine.UI;

public class UIScaler : MonoBehaviour
{
    public CanvasScaler canvasScaler; // R�f�rence au Canvas Scaler
    public Text textElement; // Exemple d'�l�ment de texte � redimensionner
    public Button buttonElement; // Exemple d'�l�ment de bouton � redimensionner

    private float screenWidth;
    private float screenHeight;
    private float aspectRatio;

    void Start()
    {
        // R�cup�rer les dimensions de l'�cran actuel
        screenWidth = Screen.width;
        screenHeight = Screen.height;

        // Calculer le rapport d'aspect
        aspectRatio = screenWidth / screenHeight;

        // Ajuster l'UI en fonction de la r�solution
        AdjustUI();
    }

    void AdjustUI()
    {
        // Exemple : ajuster la taille de la police du texte selon la largeur de l'�cran
        if (textElement != null)
        {
            if (screenWidth > 1920)
            {
                textElement.fontSize = 30; // Plus grand texte pour les grands �crans
            }
            else
            {
                textElement.fontSize = 20; // Texte plus petit pour les petits �crans
            }
        }

        // Exemple : ajuster la taille du bouton en fonction de la r�solution
        if (buttonElement != null)
        {
            RectTransform buttonRect = buttonElement.GetComponent<RectTransform>();
            if (aspectRatio >= 2f) // Rapport d'aspect plus large (comme 21:9)
            {
                buttonRect.sizeDelta = new Vector2(200, 50); // Bouton plus large
            }
            else if (aspectRatio <= 1.5f) // Rapport d'aspect plus carr� (comme 4:3)
            {
                buttonRect.sizeDelta = new Vector2(150, 40); // Bouton plus petit
            }
            else
            {
                buttonRect.sizeDelta = new Vector2(180, 45); // Bouton normal
            }
        }

        // Ajuster le Canvas Scaler pour correspondre � la taille de l'�cran
        if (canvasScaler != null)
        {
            canvasScaler.referenceResolution = new Vector2(screenWidth, screenHeight);
        }
    }

    // Optionnel : Si tu veux redimensionner l'UI dynamiquement pendant le jeu (par exemple, lors du changement d'orientation)
    void Update()
    {
        // D�tecter si la taille de l'�cran change
        if (screenWidth != Screen.width || screenHeight != Screen.height)
        {
            screenWidth = Screen.width;
            screenHeight = Screen.height;
            aspectRatio = screenWidth / screenHeight;
            AdjustUI();
        }
    }
}
