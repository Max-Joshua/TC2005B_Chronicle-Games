using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/* 
Chronicle Games
04/16/2022

->kills the player when he/she touches the object which posseses this scrip.

*/
public class FallingDead : MonoBehaviour
{
    [SerializeField] Player player;


    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;

        if(collisionGameObject.tag == "Player"){
            player.Die(0.5f);
        }
    }

}
