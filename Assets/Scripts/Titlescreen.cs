using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class Titlescreen : MonoBehaviour 
{

    public void StartGame()
    {
        SceneManager.LoadScene(3);
    }

    public void ViewInstructions()
    {
        SceneManager.LoadScene(1);
    }

    public void ViewCredits()
    {
        SceneManager.LoadScene(13);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
