using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject mainCamera; 
    public float speed = 10f;
    private Vector3 moveVector;
    public float JumpForce = 300f;
    public bool is_jump = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    void FixedUpdate()
    {
        
     
      if (Input.GetKey(KeyCode.W))
      {
        rb.AddForce(VectorTransform(mainCamera.transform.forward * speed));
      }
       if (Input.GetKey(KeyCode.S))
      {
        rb.AddForce(VectorTransform(-mainCamera.transform.forward * speed));
      }
       if (Input.GetKey(KeyCode.D))
      {
        rb.AddForce(VectorTransform(mainCamera.transform.right * speed));
      }
       if (Input.GetKey(KeyCode.A))
      {
        rb.AddForce(VectorTransform(-mainCamera.transform.right * speed));
      }
       if (Input.GetKey(KeyCode.Space) && is_jump == false)
      {
        rb.AddForce(Vector3.up * JumpForce);
        is_jump = true;
      }
      if (Input.GetKey(KeyCode.CapsLock))
      {
        speed = 0.1f;
      }
      if (Input.GetKeyUp(KeyCode.CapsLock))
      {
        speed = 1f;
      }
    }

    private Vector3 VectorTransform(Vector3 vector)
    {
        return Vector3.Scale(vector, new Vector3(1, 0, 1));
    }

    private void OnCollisionEnter(Collision collision)
    {  
      is_jump = false;
      if (collision.transform.tag == "jumpplatform")  
        {
            JumpForce = 500f;
        }
      if (collision.transform.tag == "notjump")
        {
          JumpForce = 250f;
        }
    }
}
