using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBullet : MonoBehaviour
{

    Player player;
    public float dieTime;
    public int damage;
    public GameObject die;
    
    //Audio

    // Start is called before the first frame update
    void Start(){
        StartCoroutine(CountDownTimer());
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        GameObject collisionGameObject = collision.gameObject;
    

        if(collisionGameObject.tag == "Player"){

            if(collisionGameObject.GetComponent<Player>() != null){
                
                collisionGameObject.GetComponent<Player>().TakeDamage(damage);

            }
            Die();
        }else{
            Die();
        }
    }

    IEnumerator CountDownTimer(){

        yield return new WaitForSeconds(dieTime);

        Die();
    }

    void Die(){
        Destroy(gameObject);
    }
}
