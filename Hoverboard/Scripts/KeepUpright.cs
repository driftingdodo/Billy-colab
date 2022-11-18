using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepUpright : MonoBehaviour
{

    public float upForce;
    public Rigidbody uprightRB;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        uprightRB.AddForce(Vector3.up * upForce);
    }
}
