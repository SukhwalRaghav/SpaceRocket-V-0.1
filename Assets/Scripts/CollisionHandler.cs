using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour

{
    [SerializeField] float loadleveldelay = 1f;
    [SerializeField] AudioClip landingpad;
    [SerializeField] AudioClip crash;

    [SerializeField] ParticleSystem landingpadparticles;
    [SerializeField] ParticleSystem crashparticles;

    AudioSource audiosource;
    bool isTransitioning = false;
    bool collisionDisbale = false;

    void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }
    
    void Update()
    {
        RespondToDebugKeys();
    }
     void RespondToDebugKeys()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
           LoadNextLevel(); 
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            collisionDisbale = !collisionDisbale; // ToggleBetween
        }
    }


    void OnCollisionEnter(Collision other) 
    {
        if (isTransitioning || collisionDisbale) { return; }

       switch (other.gameObject.tag)
       {
            case "Friendly":
                Debug.Log("You have started the game");
                break;
            case "Finish":
                StartSucessSequence();
                break;
            case "Fuel":
                Debug.Log("You Refill the fuel");
                break;
            default:
                StartCrashSequence();
                break;
       } 
    } 

    void StartSucessSequence()
    {
        isTransitioning = true;
        audiosource.Stop();
        audiosource.PlayOneShot(landingpad);
        landingpadparticles.Play();
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel", loadleveldelay);
        
    }
    void StartCrashSequence()
    {
        isTransitioning = true;
        audiosource.Stop();
        audiosource.PlayOneShot(crash);
        crashparticles.Play();
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", loadleveldelay);
          
    }
    

    void LoadNextLevel()
    {
        int currentsceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextsceneIndex = currentsceneIndex + 1;
        if(nextsceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextsceneIndex = 0;
        }
        SceneManager.LoadScene(nextsceneIndex);
    }
    void ReloadLevel()
    {
        int currentsceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentsceneIndex);

    }
}
