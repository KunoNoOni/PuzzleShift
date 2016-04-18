using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Potion : MonoBehaviour 
{

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            if(LevelManager.hasMouse)
            {
                Destroy(gameObject);
                LevelManager.hasBat = true;
            }
            else
            {
                Destroy(gameObject);
                LevelManager.hasMouse = true;
            }
                
        }
    }
}
