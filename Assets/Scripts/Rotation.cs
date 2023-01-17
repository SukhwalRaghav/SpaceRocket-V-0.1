using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    //public Joystick joystick;
     
    //[SerializeField] float rotationthrust  = 1f;
    //[SerializeField] float horizontalMove = 0f;
    [SerializeField] ParticleSystem leftthrustparticles;
    [SerializeField] ParticleSystem rightthrustparticles;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessRotation();
    }
    void ProcessRotation()
    {
        /*if (joystick.Horizontal >= 0.5f)
        {
            RotationRight();
        }

        else if (joystick.Horizontal <= -0.5f)
        {
            RotationLeft();
        }*/

        if (Input.GetKey(KeyCode.D))
        {
            RotationRight();
        }
        else if (Input.GetKey(KeyCode.A))
        {
            RotationLeft();
        }
    }

    private void RotationLeft()
    {
        rb.freezeRotation = true; // so we can freeze our rocket in postion
        transform.Rotate(-Vector3.forward * rotationthrust * Time.deltaTime);
        rb.freezeRotation = false; // so we unfrieezing our rocket
        rightthrustparticles.Play();
    }

    private void RotationRight()
    {
        rb.freezeRotation = true; // so we can freeze our rocket in postion
        transform.Rotate(Vector3.forward * rotationthrust * Time.deltaTime);
        rb.freezeRotation = false; // so we unfrieezing our rocket
        leftthrustparticles.Play();
    }
}
