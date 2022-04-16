using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiPatrol : MonoBehaviour
{
    public float walkSpeed, range, timeBTWShots, shootSpeed;
    private float distToPlayer;

    [HideInInspector]
    public bool mustPatrol;
    public bool mustTurn, canShoot;

    public Rigidbody2D rb;
    public Transform groundCheckPosition;
    public LayerMask groundLayer;
    public Collider2D bodyCollider;
    public Transform player, shootPos;
    public GameObject bullet;

    //Audio
    private AudioSource audioSource;
    [SerializeField] AudioClip shootingSound;
    [SerializeField] AudioSource hittingSound;
    bool isPlaying = false;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        mustPatrol = true;
        canShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(mustPatrol){
            Patrol();
        }

        distToPlayer = Vector2.Distance(transform.position, player.position);

        if(distToPlayer <= range){

            if(player.position.x > transform.position.x && transform.localScale.x < 0
                || player.position.x < transform.position.x && transform.localScale.x > 0){
                
                Flip();
                
            }

            mustPatrol = false;
            rb.velocity = Vector2.zero;

            if(canShoot){
                StartCoroutine(Shoot());
            }

        }else{
            mustPatrol = true;
        }

    }

    private void FixedUpdate() {
        if(mustPatrol){
            mustTurn = !Physics2D.OverlapCircle(groundCheckPosition.position, 0.1f, groundLayer);
        }
    }

    void Patrol(){
        if(mustTurn || bodyCollider.IsTouchingLayers(groundLayer)){
            Flip();
        }
        rb.velocity = new Vector2(walkSpeed * Time.fixedDeltaTime, rb.velocity.y);
    }

    void Flip(){
        mustPatrol = false;
        gameObject.transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        walkSpeed *= -1;
        mustPatrol = true;
    }

    IEnumerator Shoot(){
        canShoot = false;
        //Shoot
        yield return new WaitForSeconds(timeBTWShots);
        GameObject newBullet = Instantiate(bullet, shootPos.position, Quaternion.identity);

        newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(shootSpeed * walkSpeed * Time.fixedDeltaTime, 0f);    

    
        
            
        canShoot = true;
        
    }
}       
