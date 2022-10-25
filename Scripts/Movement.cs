using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;

    [SerializeField]
    float mainThrust = 1f * Time.deltaTime;
    
    [SerializeField]
    float rotationThrust = 1f * Time.deltaTime;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
       
    }

    void ProcessThrust(){
        if(Input.GetKey(KeyCode.Space)){
            rb.AddRelativeForce(Vector3.up * mainThrust);
        }
    }

    void ProcessRotation(){
        if(Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotationThrust);
        }
        else if(Input.GetKey(KeyCode.D)){
            ApplyRotation(-rotationThrust);
        }
    }

    void ApplyRotation(float ratationThisFrame)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * ratationThisFrame);
        rb.freezeRotation = false;
    }
}
