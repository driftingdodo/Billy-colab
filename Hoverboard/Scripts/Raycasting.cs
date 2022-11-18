using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycasting : MonoBehaviour
{

    public float hoverHeight = 1f;
    public float forceMultiplier;
    public float height;
    RaycastHit hit;
    public Rigidbody rb;

    

    // Update is called once per frame
    void FixedUpdate()
    {
        Ray ray = new Ray(transform.position, -transform.up);

        Debug.DrawRay(transform.position, -transform.up * height, Color.red);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.tag == "Ground")
            {
                Debug.Log(hit.distance);
            }
        }

        //if the rigidbody collides with the ground, apply a force to the rigidbody

        if (hit.distance < hoverHeight * 2f)
        {
            float force = 0.2f + hoverHeight - (transform.position.y - hit.point.y);

            force = force < 0 ? 0 : force;

            rb.AddRelativeForce(transform.up * force * forceMultiplier);
        }

        

    }

    void OnTriggerEnter(Collider other)
    {
        float force = 0.2f + hoverHeight - (transform.position.y - hit.point.y);

        force = force < 0 ? 0 : force;

        rb.AddRelativeForce(transform.up * force * forceMultiplier);
            Debug.Log("Collided with ground");
    }
}
