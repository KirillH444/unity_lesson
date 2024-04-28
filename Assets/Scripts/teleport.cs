using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class teleport : MonoBehaviour
{
    public Transform pos1;
    private void OnCollisionEnter(Collision collision)
    {   
        if (collision.transform.tag == "Player")
        {
            collision.transform.position = pos1.transform.position;
        }
    }
}