using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lines : MonoBehaviour
{

   

    public float HorizontalSpeed = 250 ;
     public float MaxHorizontalPosition = 200 ;
     public float MinHorizontalPosition = -200 ;
     
     // Please, name correctly your variables.
     // Yourself, in 3 months will be grateful    
     public RectTransform rectTransform;
     
     void Start ()
     {
         rectTransform = GetComponent<RectTransform>();
     }
     
     void Update ()
     {
         Vector2 position = rectTransform.anchoredPosition;
     
         position.x += HorizontalSpeed * Time.deltaTime;
         
         if( position.x > MaxHorizontalPosition )
         {
            position.x = MinHorizontalPosition;
         }
     
         rectTransform.anchoredPosition = position;
     }



     
}
