using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSpace : MonoBehaviour
{
    Player player;
    Lines line;

    
    [SerializeField] GameObject pla;
     void Awake()
     {
         player = pla.GetComponent<Player>();
        

     }


        //Tried to have another heart in the same pos with diferent collider so when the player pressed space, Gordilla heal and the bars disappear

    void OnTriggerStay2D(Collider2D other)
    {

        if (Input.GetKeyDown(KeyCode.Space) && player.currentHealth != player.maxHealth)
        {

                if (player.currentHealth != player.maxHealth)
                {
                    player.Heal(10);
                }
        }
    }

}
