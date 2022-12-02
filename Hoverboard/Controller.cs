using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public List<GameObject> balls;
    public Rigidbody rb;
    public GameObject prop;
    public GameObject CM;
    public float speed = 400f;

    // Start is called before the first frame update
    void Start()
    {
        rb.centerOfMass = CM.transform.localPosition;
        //lock the cursor
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForceAtPosition(Time.deltaTime * transform.TransformDirection(Vector3.forward) * Input.GetAxis("Vertical") * speed, prop.transform.position);
        rb.AddTorque(Time.deltaTime * transform.TransformDirection(Vector3.up) * Input.GetAxis("Horizontal") * 200f);
        foreach (GameObject ball in balls)
        {
            RaycastHit hit;
            if (Physics.Raycast(ball.transform.position, transform.TransformDirection(Vector3.down), out hit, 3f))
            {
                rb.AddForceAtPosition(Time.deltaTime * transform.TransformDirection(Vector3.up) * Mathf.Pow(3f - hit.distance, 2) / 3f * 250f, ball.transform.position);
            }
            Debug.Log(hit.distance);


        }
        rb.AddForce(-Time.deltaTime * transform.TransformVector(Vector3.right) * transform.InverseTransformVector(rb.velocity).x * 5f);

        //jump when on ground
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RaycastHit hit2;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit2, 2f))
            {
                rb.AddForce(transform.TransformDirection(Vector3.up) * 500f);
                //while hit.distance is more than 2, transfrom CM upwards by 0.5f

            }
        }
        //draw a ray downwards and check the distance to the ground
        RaycastHit hit3;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit3, 10f))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hit3.distance, Color.yellow);
            //while hit3.distance is more than 2, add touque upwards
            if (hit3.distance > 4f)
            {
                rb.AddTorque(transform.TransformDirection(Vector3.left) * 2f);
            }


        }
        // if R is pressed, reset the position of the car
        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.position = new Vector3(0f, 1f, 0f);
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
        
        //when pressing shift give the car a boost in the direction it is facing when on ground
        
        if (Input.GetKey(KeyCode.LeftShift))
        {
            RaycastHit hit2;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit2, 2f))
            {
                rb.AddForce(transform.TransformDirection(Vector3.forward) * 300f);
               

            }
            
        }
    }


}


