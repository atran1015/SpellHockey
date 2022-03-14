using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //When Play Game button is pressed, move to gameplay scene
    public void PlayGame()
    {
        //Scene Manager must have scenes in order as this function looks for the next scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
