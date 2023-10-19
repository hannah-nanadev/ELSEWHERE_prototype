using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField]
    private string overworldScene = "Overworld";
    [SerializeField]
    private string mainMenuScene = "MainMenu";
    [SerializeField]
    private string optionsScene = "Options";

    // Start Game option
    void StartGame()
    {
        SceneManager.LoadScene(overworldScene);
    }

    // Open Options option
    void OpenOptions()
    {
        SceneManager.LoadScene(optionsScene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
