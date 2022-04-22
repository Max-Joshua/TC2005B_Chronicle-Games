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
    public ParticleSystem Explosion;
    
     [SerializeField] GameObject pla;
     void Awake()
     {
         player = pla.GetComponent<Player>();
     }


     void Update()
     {
         transform.SetAsLastSibling();

        if (Input.GetKeyDown(KeyCode.Space) && canPress)
        {
            Debug.Log("Pressed");
            if ((player.currentHealth != player.maxHealth) && canHeal )
            {
                Explosion.Play();
                player.Heal(1);
                Debug.Log("Healed!");
                canHeal = false;
            }
            Damage = false;

        }

        if (Input.GetKeyDown(KeyCode.Space) && !canPress)
        {
            player.TakeDamage(0);

            Debug.Log("Missed!");
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
