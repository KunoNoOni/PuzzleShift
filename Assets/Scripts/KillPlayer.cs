using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class KillPlayer : MonoBehaviour 
{
    public GameObject deathParticle;

    private LevelManager levelManager;

	void Start () 
	{
        levelManager = FindObjectOfType<LevelManager>();

	}
	
    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("I am the "+this.name+"."+" And I just killed the player!");
        if(other.tag == "Player")
        {
            LevelManager.numberOfDeaths++;
            Instantiate(deathParticle,other.transform.position, other.transform.rotation);
            levelManager.RespawnPlayer();
        }
    }
}
