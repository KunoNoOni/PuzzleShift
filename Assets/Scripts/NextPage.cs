using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class NextPage : MonoBehaviour 
{
    public int pageToLoad;

    public void NextPageToLoad()
    {
        SceneManager.LoadScene(pageToLoad);
    }
}
