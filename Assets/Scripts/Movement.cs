 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //public Joystick joystick;
    [SerializeField] float mainthrust = 100f;
    [SerializeField] float rotationthrust  = 1f; 
    [SerializeField] AudioClip mainengine;
    [SerializeField] ParticleSystem mainethrustparticle;
    [SerializeField] ParticleSystem leftthrustparticles;
    [SerializeField] ParticleSystem rightthrustparticles;
    Rigidbody rb;
    AudioSource audiosource;
    //[SerializeField] float horizontalMove = 0f;
    //[SerializeField] float VerticalMove = 0f;
    

    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audiosource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        /*if (joystick.Vertical >= 0.2f)
        {
            StartThrusting();
        }
        else if  (joystick.Vertical >= -0.2f)
        {
            VerticalMove = -StartThrusting();
        }
        else
        {
            VerticalMove = 0f;
        }*/

        if (Input.GetKey(KeyCode.Space))
        {
            StartThrusting();

        }
        else
        {
            audiosource.Stop();
            mainethrustparticle.Stop();
        }

    }

    void StartThrusting()
    {
        rb.AddRelativeForce(Vector3.up * mainthrust * Time.deltaTime);
        if (!audiosource.isPlaying)
        {
            audiosource.PlayOneShot(mainengine);
        }
        mainethrustparticle.Play();
    }

   void ProcessRotation()
    {
        /*if (joystickD.Horizontal >= 0.5f)
        {
            RotationRight();
        }

        else if (joystickD.Horizontal <= -0.5f)
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
