using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class death : MonoBehaviour
{
    public int levelnum = 0;
    private void OnCollisionEnter(Collision collision)
    {   
        if (collision.transform.tag == "Player")
        {
            SceneManager.LoadScene(levelnum);
        }
    }
}
