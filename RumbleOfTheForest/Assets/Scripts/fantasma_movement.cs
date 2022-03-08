using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fantasma_movement : MonoBehaviour
{
    public float Speed;
    public float JumpForce;

    private Rigidbody2D rigidbody2D;
    public Animator animator;
    private float Horizontal;
    private bool Grounded;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");

        if (Horizontal >= 0){
            transform.localScale = new Vector3(1,1,1);
        }
        else{
            transform.localScale = new Vector3(-1,1,1);
        }

        if (Horizontal != 0){
            animator.SetBool("Running", true);
        }
        else{
            animator.SetBool("Running", false);
        }

        if(Input.GetKeyDown(KeyCode.UpArrow) && Grounded){
            Jump();
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "ground")
            Grounded = true;
    }

    private void OnCollisionExit2D(Collision2D other) {
        if (other.gameObject.tag == "ground")
            Grounded = false;
    }

    private void Jump(){
        rigidbody2D.AddForce(Vector2.up * JumpForce);
    }

    private void FixedUpdate(){
        rigidbody2D.velocity = new Vector2(Horizontal, rigidbody2D.velocity.y);
    }
}
