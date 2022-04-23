using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiPatrol : MonoBehaviour
{
    public float walkSpeed, range, timeBTWShots, shootSpeed, health;
    private float distToPlayer;

    [HideInInspector]
    public bool mustPatrol;
    public bool mustTurn, canShoot;

    public Rigidbody2D rb;
    public Transform groundCheckPosition;
    public LayerMask groundLayer;
    public LayerMask Enemies;
    public Collider2D bodyCollider;
    public Transform player, shootPos;
    public GameObject Bullet;

    //Audio
    bool isPlaying = false;
    

    // Start is called before the first frame update
    void Start()
    {

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
        if(mustTurn || bodyCollider.IsTouchingLayers(groundLayer) || bodyCollider.IsTouchingLayers(Enemies)){

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
        GameObject newBullet = Instantiate(Bullet, shootPos.position, Quaternion.identity);

        if(gameObject.transform.localScale.x <= -1){
            Debug.Log("Shoot Left");
            newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(shootSpeed * walkSpeed * Time.fixedDeltaTime, 0f);
            newBullet.transform.localScale = new Vector2(transform.localScale.x + .3f, transform.localScale.y - .3f);      
        }else{
            Debug.Log("Shoot Right");
            newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(shootSpeed * walkSpeed * Time.fixedDeltaTime, 0f);
        
        }
        canShoot = true;
        
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if(health <= 0){
            Die();
        }
    }

    public void Die(){
        Score.scoreValue += 10;
        
        Destroy(gameObject);
    }

}