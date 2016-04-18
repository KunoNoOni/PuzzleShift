using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MoveParticle : MonoBehaviour 
{
    public float moveSpeed;

    private Rigidbody2D rb2D;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

	void Update () 
	{
        rb2D.velocity = new Vector2(moveSpeed * Time.deltaTime,0);
	}
}
