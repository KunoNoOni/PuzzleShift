using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class NextLevel : MonoBehaviour 
{
    void OnTriggerEnter2D(Collider2D other)
    {
        
        if(other.tag == "Player")
        {
//            if(LevelManager.levelNum == 3)
//                LevelManager.levelNum = 0;
//            else
            LevelManager.levelNum += 1;
            Debug.Log("Levelnum is "+LevelManager.levelNum);
            SceneManager.LoadScene(LevelManager.levelNum);
        }
            
    }
}
