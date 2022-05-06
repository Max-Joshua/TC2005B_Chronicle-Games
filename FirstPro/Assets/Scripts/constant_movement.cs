using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* 
Chronicle Games
04/01/2022

-> In order to make the parallax script funtion, it and the camera must follow an object that moves
    so this script was assigned to an empty object in the menu scene in order to make the parallax script
    function correclty
 

*/
public class constant_movement : MonoBehaviour
{
    // Start is called before the first frame update
   
    public float speed;
    float moveVelocity;



     void Update()
     {
         moveVelocity = speed;
        GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveVelocity, GetComponent<Rigidbody2D> ().velocity.y);
     }
}
