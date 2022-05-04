using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* 
Chronicle Games
04/09/2022

Enemy AI script
-> Controlls enemy movement
-> Controlls enemy shooting behaviour
-> Controlls the enemy's dead

*/
public class AiPatrol : MonoBehaviour
{
    public float walkSpeed, range, timeBTWShots, shootSpeed, health;
    private float distToPlayer;

    [HideInInspector]
    public bool mustPatrol;
    public bool mustTurn, canShoot;

    public int scoreEValue;
    public Rigidbody2D rb;
    public Transform groundCheckPosition;
    public LayerMask groundLayer;
    public LayerMask Enemies;
    public Collider2D bodyCollider;
    public Transform player, shootPos;
    public GameObject Bullet;
    public ParticleSystem Explosion;
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

//When the object "Ground Check Position" collision box does not detect a "ground layer" tile, mustTurn will become True
    private void FixedUpdate() {
        if(mustPatrol){
            mustTurn = !Physics2D.OverlapCircle(groundCheckPosition.position, 0.1f, groundLayer);
        }
    }

//Behaviour where the enemy wont chase the player, it will patrol an area defined either by a void and/or a wall
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

//Manages when the enemy can and can not shoot
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
        player.GetComponent<Player>().InflictDamage(damage);
        if(health <= 0){
            Die();
        }
    }

    public void Die(){

        Instantiate(Explosion, transform.position, transform.rotation);
        Score.scoreValue += scoreEValue;
        
        Destroy(gameObject);
    }

}