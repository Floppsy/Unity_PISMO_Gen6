using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    public Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //Kretanje desno
        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            //transform.position += Vector3.right * speed;
            rb.AddForce(Vector3.right * speed);
        }
        //Kretanje lijevo
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            //transform.position += Vector3.left * speed;
            rb.AddForce(Vector3.left * speed);
        }
    }
}
