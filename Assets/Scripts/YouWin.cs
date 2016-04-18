using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class YouWin : MonoBehaviour 
{

    public void ViewCredits()
    {
        SceneManager.LoadScene(13);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
