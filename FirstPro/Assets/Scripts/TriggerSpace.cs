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

    //Particles and animations
    public ParticleSystem Explosion;
    private Animator animator;
    
     [SerializeField] GameObject pla;

    void Start(){
        animator = GetComponent<Animator>();
    }
    
     void Awake()
     {
         player = pla.GetComponent<Player>();
         
     }


     void Update()
     {
         transform.SetAsLastSibling();

        if (Input.GetKeyDown(KeyCode.Space) && canPress)
        {
            Explosion.Play();
            CinemachineShake.Instance.ShakeCamera(0.05F, .1F);
            animator.SetBool("isHealing", true);

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
            player.TakeDamage(0);

            Debug.Log("Missed!");
            animator.SetBool("isHealing", false);
        }

     }


        //Tried to have another heart in the same pos with diferent collider so when the player pressed space, Gordilla heal and the bars disappear

    void OnTriggerEnter2D(Collider2D other)
    {

        canPress = true;

    }

    void OnTriggerExit2D(Collider2D other)
    {

        canPress = false;

        if (Damage)
        {
            player.TakeDamage(1);
            Debug.Log("Auch!");
        }

        Damage = true;
        canHeal = true;
    }

}
