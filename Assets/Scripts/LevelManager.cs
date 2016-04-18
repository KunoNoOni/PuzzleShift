using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour 
{
    //private PlayerController player;
    //private MouseController mousePlayer;
    public GameObject player;
    public GameObject mousePlayer;
    public GameObject batPlayer;
    public static bool hasMouse = false;
    public static bool hasBat = false;
    public static int levelNum = 3;
    public Slider stamina;
    public static bool stopChecking = false;
    public static int numberOfDeaths = 0;



	void Start () 
    {
        stamina = FindObjectOfType<Slider>();

	}
	
    void Update()
    {
        if(!stopChecking)
        {
            if(hasBat)
            {
                stopChecking = true;
                stamina.gameObject.SetActive(true);
            }
            else
                stamina.gameObject.SetActive(false);
        }
    }

    public void RespawnPlayer()
    {
        StartCoroutine("RespawnPlayerCo");
    }

    public IEnumerator RespawnPlayerCo()
    {

        if(player.activeSelf == false)
        {
            if(mousePlayer.activeSelf == false)
            {
                //Debug.Log("batPlayer is DEACTIVATED");
                batPlayer.SetActive(false);
            }
            else
            {
                //Debug.Log("mousePlayer was DEACTIVATED");
                mousePlayer.SetActive(false);
            }
        }
        else
        {
            //Debug.Log("Player was DEACTIVATED");
            player.gameObject.SetActive(false);
        }

        yield return new WaitForSeconds(2f);
        //Debug.Log("Player was ACTIVATED");
        player.gameObject.SetActive(true);
        Debug.Log("Levelnum is "+levelNum);
        if(levelNum == 5)
            hasMouse = false;
        if(levelNum == 8)
        {
            stopChecking = false;
            hasBat = false;
        }
        SceneManager.LoadScene(levelNum);
    }
}
