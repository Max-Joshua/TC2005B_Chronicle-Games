using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* 
Chronicle Games
04/10/2022

-> Detects when the player can or can't attack, gain points/health or loose points/health based on the position of the "rhythm bars"


*/
public class TriggerSpace : MonoBehaviour
{
    Player player;
    Lines line;
    public float totalHitBars;
    public bool Damage;
    public bool canHeal = true;
    bool canPress = false;          //Determines when the player will be able to gain points/health from a "rhythm bar" 
                                    //If the "rhythm bar" enters the collision box of the "RhythmHearSpace" object
                                    // "canPress" will become true, otherwise it will remain false.
    public GameObject Bullet;
    public Transform shootPos;
    public Movement movementScript;

    //Particles and animations
    public ParticleSystem Explosion;
    private Animator animator;
    
     [SerializeField] GameObject pla;

    [HideInInspector]
    public bool canShoot;

    public AudioSource play;

    public AudioClip heartBeat;

    public AudioClip missedHeartBeat;
    public bool musicIsPlaying = false;

    void Start(){
        animator = GetComponent<Animator>();
        canShoot = true;

        
    }
    
     void Awake()
     {
         player = pla.GetComponent<Player>();
         
     }


     void Update()
     {
         transform.SetAsLastSibling();
        
        if (Input.GetKeyDown(KeyCode.Space) && canPress && canShoot)
        {
            addPoints(1);
            totalHitBars += 1f;
            AudioSource.PlayClipAtPoint(heartBeat, player.transform.position);

            if(Input.GetKey(KeyCode.E) && (player.currentPower >= 0 && player.currentPower == player.maxPower)){
                
                    GameObject newBullet = Instantiate(Bullet, shootPos.position, Quaternion.identity);
                    
                    //If player is looking left, the clone of the bullet prefab will be inverted, so that the particles will follow and their directon makes sense.
                    if(player.transform.localScale.x <= -1){ 
                        newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(movementScript.shootSpeed * -movementScript.speed * Time.fixedDeltaTime, 0f);
                        newBullet.transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);    
                        player.UsePower();
                    }else{
                        newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(movementScript.shootSpeed * movementScript.speed * Time.fixedDeltaTime, 0f);    
                        player.UsePower();
                    }
                
            }

            Explosion.Play();
            CinemachineShake.Instance.ShakeCamera(0.05F, .1F);
            animator.SetBool("isHealing", true);
            animator.SetBool("isHurt", false);

            //Does not let the player cheat, he/she will only be able to regain power if the "E" key is not constantlly pressed.
            if((player.currentPower != player.maxPower) && canShoot && !Input.GetKey(KeyCode.E) ){
                
                player.RegainPower();
            }
            
            Debug.Log("Pressed");
            if ((player.currentHealth != player.maxHealth) && canHeal )
            {

                player.Heal(1);
                Debug.Log("Healed!");
                canHeal = false;
            }
            Damage = false;
            
        }else{
            animator.SetBool("isHealing", false);
        }
        
        //When the player misses the hitbox of the "RhythmHearSpace" object, he/she will take damage.
        if (Input.GetKeyDown(KeyCode.Space) && !canPress)
        {
            substractPoints(1);
            AudioSource.PlayClipAtPoint(missedHeartBeat, player.transform.position, 0.2f);
            player.TakeDamage(0);

            Debug.Log("Missed!");
            animator.SetBool("isHurt", true);
            animator.SetBool("isHealing", false);
        }
        if(animator.GetCurrentAnimatorStateInfo(0).IsName("Damage") && 
            animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
            {
                animator.SetBool("isHurt", false);
            }
     }


    //Activates when the "Rhythm bars" enter the "RhythmHearSpace" object collision box.
    void OnTriggerEnter2D(Collider2D other)
    {
        
        canPress = true;
        canShoot = true;
        

        if(!musicIsPlaying)
        {
        play.Play();
        musicIsPlaying = true;
        }
    }
    //Activates when the "Rhythm bars" exit the "RhythmHearSpace" object collision box.
    void OnTriggerExit2D(Collider2D other)
    {

        canPress = false;
        canShoot = false;

        if (Damage)
        {
            player.TakeDamage(1);
            Debug.Log("Auch!");
        }

        Damage = true;
        canHeal = true;
    }

    void addPoints(int points){
        Score.scoreValue += points;
    }

    void substractPoints(int points){
        Score.scoreValue -= points;
    }


}
