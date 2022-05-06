using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* 
Chronicle Games
03/15/2022

-> Determines the speed of the instantiated element and limits the object to a minimum and maximum
    position on the screen
 

*/
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

}
