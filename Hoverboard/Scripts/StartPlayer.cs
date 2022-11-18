using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPlayer : MonoBehaviour
{
    public float speed = 100f;
    
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //move forward when w is pressed
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(transform.forward * speed);
        }
        //move backward when s is pressed
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(-transform.forward * speed);
        }

        transform.eulerAngles += transform.up * Input.GetAxis("Horizontal");

    }
}
