using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject optionsCanvas; 
    // Start is called before the first frame update
    public void Startgame()
    {
        SceneManager.LoadScene("test jeu 1");
    }

  
    public void Quitgame()
    {
        Debug.Log("Quitter le jeu");
        Application.Quit();
    }
}
