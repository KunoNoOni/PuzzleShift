using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class DestroyEffect : MonoBehaviour 
{
    private ParticleSystem effect;

	void Start () 
	{
        effect = GetComponent<ParticleSystem>();
	}
	
	void Update () 
	{
        if(effect.isPlaying)
            return;

        Destroy(gameObject);
	}
}
