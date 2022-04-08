using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class testSound : MonoBehaviour
{
    //AudioSource audiosource;
    [SerializeField] float delay;

    //When is the next hit going to happen
    float nextStep;

    private AudioSource audioSource;
    public AudioClip[] walkingSounds;
    private AudioClip walkingClip;

    [SerializeField] AudioClip jumping;
    [SerializeField] AudioSource walking;


    bool isPlaying = false;
    bool isWalking;

    // Start is called before the first frame update
    void Start()
    {
        //Initialize the variable for the time
        audioSource = gameObject.GetComponent<AudioSource>();
        nextStep = delay;
    }

    // Update is called once per frame
    void Update()
    {
        if (!PauseMenu.GameIsPaused)
        {
            if(Input.GetKeyDown(KeyCode.Space)){
                audioSource.clip = jumping;

                if(isPlaying){
                audioSource.Stop();
                }else{
                    audioSource.Play();
                }
                isPlaying = false;
            }
            if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A)){
                isWalking = true;
            }

            if(Input.GetKeyUp(KeyCode.D)){
                isWalking = false;
            }
            if(Input.GetKeyUp(KeyCode.A)){
                isWalking = false;
            }
            //Timer for each step sound

            nextStep -= Time.deltaTime;

            if(nextStep <= 0)
            { 
                nextStep = delay;

                if(isWalking && !walking.isPlaying)
                {
                    int index = Random.Range(0, walkingSounds.Length);
                    walkingClip = walkingSounds[index];
                    audioSource.clip = walkingClip;
                    audioSource.Play();
                }

                if(isWalking == false)
                {
                    nextStep = 0;
                }
            }
        }
    }
}
/* Limitar el tiempo en el que un jugador puede activar el sonido

    void fixedUpdate(){
        if(Time.time >= nextJump){

            jumping.Play();
            nextJump = Time.time + delay;
            
        }
    } */

