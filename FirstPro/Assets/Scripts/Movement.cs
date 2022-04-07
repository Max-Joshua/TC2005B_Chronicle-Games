using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //Movement
    public float speed;
    public float jump;
    float moveVelocity;
    private Animator animator;
    

    //Grounded Vars
    bool grounded = true;
    
    
    void Start(){
        animator = GetComponent<Animator>();
    }
    void Update () 
    {
        //Jumping
        if (Input.GetKeyDown (KeyCode.Space) || Input.GetKeyDown (KeyCode.UpArrow) || Input.GetKeyDown (KeyCode.Z) || Input.GetKeyDown (KeyCode.W)) 
        {
            if(grounded)
            {
                GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x, jump);
                animator.SetBool("isJumping", true);
                
            }
        }else{

            animator.SetBool("isJumping", false);

        }


        moveVelocity = 0;
        animator.SetBool("isWalking", false);

        //Left Right Movement
        if (Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.A)) 
        {
            moveVelocity = -speed;

            gameObject.transform.localScale = new Vector3(-1, 1, 1);
            
            animator.SetBool("isWalking", true);
        }
        if (Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.D)) 
        {
            moveVelocity = speed;
            gameObject.transform.localScale = new Vector3(1, 1, 1);
            
            animator.SetBool("isWalking", true);
        }

        GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveVelocity, GetComponent<Rigidbody2D> ().velocity.y);

    }
    //Check if Grounded
    void OnTriggerEnter2D(Collider2D other)
    {
        grounded = true;
        animator.SetBool("isJumping", false);
    }
    
    void OnTriggerExit2D(Collider2D other) 
    {
        grounded = false;
        animator.SetBool("isJumping", true);
    }
}
