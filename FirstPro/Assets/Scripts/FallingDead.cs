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
    Player player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;

        if(collisionGameObject.tag == "Player"){
            Restart();
        }
    }

    void Restart()
    {
        Score.scoreValue = 0;
        SceneManager.LoadScene(1);
    }
}
