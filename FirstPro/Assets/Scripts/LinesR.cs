using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinesR : MonoBehaviour
{

    Player player;
     public float HorizontalSpeed = -100 ;
     public float MaxHorizontalPosition = 8 ;
     public float MinHorizontalPosition = 460 ;
       
     private RectTransform rectTransform;
     
     void Start ()
     {
         rectTransform = GetComponent<RectTransform>();
     }
     
     void Update ()
     {
         Vector2 position = rectTransform.anchoredPosition;
     
         position.x -= HorizontalSpeed * Time.deltaTime;
         
         if( position.x < MaxHorizontalPosition )
             position.x = MinHorizontalPosition ;
     
         rectTransform.anchoredPosition = position;
     }


    //   public void OnTriggerEnter(Collider other)
    //   {
    //       Debug.Log("LinesR");

    //       Vector2 position = rectTransform.anchoredPosition;
          
    //       if (Input.GetKeyDown(KeyCode.Space) && player.currentHealth != player.maxHealth)
    //         {
    //             position.x = MinHorizontalPosition;
    //             rectTransform.anchoredPosition = position;

    //             if (player.currentHealth != player.maxHealth)
    //             {
    //                 player.Heal(10);
    //             }
    //         }
          
    //   }
}
