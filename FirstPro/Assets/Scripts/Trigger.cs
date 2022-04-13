using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trigger : MonoBehaviour
{

     Player player;
     public GameObject player_;


     
     void Start()
     {
         player = player_.GetComponent<Player>();
         transform.SetAsLastSibling();
     }


     void Update ()
     {
       transform.SetAsLastSibling();
     }


    //Each time the bars hit the heart in the center, the player takes 2 damage 
      // void OnTriggerEnter2D(Collider2D other)
      // {

      //   if (!noDamage)
      //   {
      //   player.TakeDamage(0);
      //   }

      // }

}
