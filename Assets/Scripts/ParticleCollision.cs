using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ParticleCollision : MonoBehaviour 
{

    public GameObject explosion;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Ground" || other.tag == "Player")
        {
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

}
