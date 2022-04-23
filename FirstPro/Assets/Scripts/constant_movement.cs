using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
