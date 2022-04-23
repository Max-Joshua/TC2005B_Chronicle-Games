using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSpace : MonoBehaviour
{
    Player player;
    Lines line;

    public bool Damage;
    public bool canHeal = true;
    bool canPress = false;

    public GameObject Bullet;
    public Transform shootPos;
    public Movement movementScript;

    //Particles and animations
    public ParticleSystem Explosion;
    private Animator animator;
    
     [SerializeField] GameObject pla;

    [HideInInspector]
    public bool canShoot;

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

            if(Input.GetKeyDown(KeyCode.E) && (player.currentPower >= 0 && player.currentPower == 3)){
                
                    GameObject newBullet = Instantiate(Bullet, shootPos.position, Quaternion.identity);
                    
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

            if((player.currentPower != player.maxPower) && canShoot && !Input.GetKeyDown(KeyCode.E) ){

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
        

        if (Input.GetKeyDown(KeyCode.Space) && !canPress)
        {
            substractPoints(1);
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


        //Tried to have another heart in the same pos with diferent collider so when the player pressed space, Gordilla heal and the bars disappear

    void OnTriggerEnter2D(Collider2D other)
    {

        canPress = true;
        canShoot = true;

    }

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
