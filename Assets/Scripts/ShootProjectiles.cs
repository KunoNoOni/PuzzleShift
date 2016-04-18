using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ShootProjectiles : MonoBehaviour 
{
    public GameObject projectile;
    public float cooldown = 2f;
    public float cooldownRate = 2f;
    public AudioSource asource;
    public AudioClip arrow;
    public AudioClip fireball;


	void Update () 
	{
        cooldown -= Time.deltaTime;

        if (cooldown < 0)
        {
            cooldown = cooldownRate;
            if(this.tag == "Arrow")
            {
                asource.clip = arrow;
                asource.Play();
            }
            if(this.tag == "Fireball")
            {
                asource.clip = fireball;
                asource.Play();
            }
            Instantiate(projectile,this.transform.position,projectile.transform.rotation);
        }
	}
}
