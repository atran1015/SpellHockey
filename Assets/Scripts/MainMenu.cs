using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //When Play Game button is pressed, move to gameplay scene
    public void PlayGame()
    {
        SceneManager.LoadScene(sceneName: "GameScene");
    }
    public void GoToCredits()
    {
        SceneManager.LoadScene(sceneName: "CreditsScene");
    }

    public void QuitGame()
    {
        Debug.Log("quitting game");
        Application.Quit();
    }
}
