using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinLose : MonoBehaviour
{
    public GameObject WinLosePanel;
    public static bool isOnHold;
    public Button win;
    public Button lose;

    public scoring_system score;
    private static int playerScore;
    private static int opponentScore;

    // Update is called once per frame
    void Update()
    {
        playerScore = score.redhealth;
        opponentScore = score.bluehealth;
        if (playerScore == 1)
        {
            if (isOnHold == true)
            {

                PlayGame();
            }
            else
            {
                lose.gameObject.SetActive(true);
                win.gameObject.SetActive(false);
                PauseGame();
            }
        } 
        else if (opponentScore == 1)
        {
            if (isOnHold == true)
            {
                PlayGame();
            }
            else
            {
                lose.gameObject.SetActive(false);
                win.gameObject.SetActive(true);
                PauseGame();
            }
        }

    }

    void PauseGame()
    {
        
        Cursor.visible = true;
        WinLosePanel.SetActive(true);
        Time.timeScale = 0f;
        isOnHold = false;
        
    }

    public void PlayGame()
    {
        WinLosePanel.SetActive(false);
        Time.timeScale = 1f;
        isOnHold = true;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(sceneName: "MainMenuScene");
    }

    public void QuitGame()
    {
        Debug.Log("quitting game");
        Application.Quit();
    }
}
