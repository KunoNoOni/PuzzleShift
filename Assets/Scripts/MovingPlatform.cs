using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MovingPlatform : MonoBehaviour 
{
    public Transform[] points;
    public float moveSpeed;
    public int pointSelection;

    private Transform currentPoint;


	void Start () 
	{
        currentPoint = points[pointSelection];
	}
	
	void Update () 
	{
        this.transform.position = Vector3.MoveTowards(this.transform.position,currentPoint.position, moveSpeed * Time.deltaTime);

        if(this.transform.position == currentPoint.position)
        {
            pointSelection++;

            if(pointSelection == points.Length)
            {
                pointSelection = 0;
            }

            currentPoint = points[pointSelection];
        }
	}
}
