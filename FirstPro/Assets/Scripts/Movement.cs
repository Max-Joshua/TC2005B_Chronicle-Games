using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* 
Chronicle Games
04/18/2022

-> Controlls every aspect of the player's movement including it's animation components and 
    sound emittions 
*/
public class Movement : MonoBehaviour
{
    //Player Sounds
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

    //Movement
    public float speed, shootSpeed;
    public float jump;
    public float moveVelocity;
    private Animator animator;
    public bool Grounded;

    public bool doubleJump;

    
    void Start(){
        animator = GetComponent<Animator>();
        audioSource = gameObject.GetComponent<AudioSource>();
        nextStep = delay;
    }
    void Update () 
    {

        if(!PauseMenu.GameIsPaused)
        {

            //Jumping
            if (Input.GetKeyDown (KeyCode.UpArrow)) 
            {
                if(Grounded || doubleJump)
                {
                        
                    GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x, jump);
                    SuperJump();
                    animator.SetBool("isJumping", true);

                audioSource.clip = jumping;

                if(isPlaying){
                    audioSource.Stop();
                }else{
                    audioSource.Play();
                }
                    isPlaying = false;
                }
            }else{

                animator.SetBool("isJumping", false);

            }


            moveVelocity = 0;
            animator.SetBool("isWalking", false);

            //Left Right Movement
            if (Input.GetKey (KeyCode.LeftArrow)) 
            {
                moveVelocity = -speed;

                gameObject.transform.localScale = new Vector3(-1, 1, 1);
                
                animator.SetBool("isWalking", true);
            }
            if (Input.GetKey (KeyCode.RightArrow)) 
            {
                moveVelocity = speed;
                gameObject.transform.localScale = new Vector3(1, 1, 1);
                
                animator.SetBool("isWalking", true);
            }

            GetComponent<Rigidbody2D>().velocity = new Vector2 (moveVelocity, GetComponent<Rigidbody2D> ().velocity.y);

            if(Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow)){
                isWalking = true;
            }

            if(Input.GetKeyUp(KeyCode.RightArrow)){
                isWalking = false;
            }
            if(Input.GetKeyUp(KeyCode.LeftArrow)){
                isWalking = false;
            }

            //Timer for each step sound
            nextStep -= Time.deltaTime;

            if(nextStep <= 0){ 
                nextStep = delay;

                if(isWalking && !walking.isPlaying && Grounded){
                    int index = Random.Range(0, walkingSounds.Length);
                    walkingClip = walkingSounds[index];
                    audioSource.clip = walkingClip;
                    audioSource.Play();
                }

                if(isWalking == false && Grounded){
                    nextStep = 0;
                }
                    }
        }

    }
            //Check if Grounded
                private void OnCollisionEnter2D(Collision2D other) {
                if (other.gameObject.tag == "ground")
                    Grounded = true;
                    doubleJump = true;
                }

                private void OnCollisionExit2D(Collision2D other) {
                if (other.gameObject.tag == "ground")
                    Grounded = false;
                }


                private void SuperJump()
                {
                    if (!Grounded && doubleJump)
                    {
                    GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x, jump);
                    doubleJump = false;
                    }
                }



                
                
}
