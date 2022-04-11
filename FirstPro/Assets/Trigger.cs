using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trigger : MonoBehaviour
{

     Player player;
    [SerializeField] GameObject pla;
     void Awake()
     {
         player = pla.GetComponent<Player>();
     }


    //Each time the bars hit the heart in the center, the player takes 2 damage 
     void OnTriggerEnter2D(Collider2D other)
     {

        player.TakeDamage(2);
     }

}
