using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class AnimatedSpike : MonoBehaviour 
{
    public float cooldown = 2f;
    public float cooldownRate = 2f;

    private bool retracted = true;

	void Update () 
	{
        cooldown -= Time.deltaTime;
        if(cooldown < 0)
        {
            cooldown = cooldownRate;
            if(retracted)
            {
                retracted = false;
                this.transform.position = new Vector3(this.transform.parent.position.x, this.transform.parent.position.y+.48f, this.transform.parent.position.z);
            }
            else
            {
                retracted = true;
                this.transform.position = new Vector3(this.transform.position.x, this.transform.parent.position.y, this.transform.position.z);
            }

        }
	}
}
