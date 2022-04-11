using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinesR : MonoBehaviour
{
    public float HorizontalSpeed = -250 ;
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


    //  private void OnTriggerEnter2D(Collider2D other)
    //  {
    //      Debug.Log("Hit");
    //  }
}
