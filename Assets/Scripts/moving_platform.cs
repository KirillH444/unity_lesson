using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moving_platform : MonoBehaviour
{
    public Transform leftPoint;
    public Transform rightPoint;

    public float speed = 2f;
    private bool moveRight = true;

void Update() 
{
    if (moveRight)
    {
        transform.position = Vector3.MoveTowards(transform.position, rightPoint.position, speed * Time.deltaTime);

        if (transform.position == rightPoint.position)
        {
            moveRight = false;
        }
    }
    else
    {
        transform.position = Vector3.MoveTowards(transform.position, leftPoint.position, speed * Time.deltaTime);
        if (transform.position == leftPoint.position)
        {
            moveRight = true;
        }
    }   
}
}