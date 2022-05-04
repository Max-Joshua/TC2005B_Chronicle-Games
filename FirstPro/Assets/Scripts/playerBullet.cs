using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* 
Chronicle Games
04/10/2022

Player bullet attributes and behavour

->The bullet will recognize what it is about to touch
->The bullet will ignore the "crowBullet" tag objects
->The bullet collide with the "Enemy" and "Boss" tag objects

*/
public class playerBullet : MonoBehaviour
{

    Player player;
    AiPatrol aiScript;
    tempTenochAI tenochAI;
    public float dieTime;
    public int damage;
    public GameObject die;
    public AudioClip hitSource;
    public GameObject playerPos;
    public ParticleSystem Explosion;

    // Start is called before the first frame update
    void Start(){

        StartCoroutine(CountDownTimer());
        Transform Bullet = GameObject.FindWithTag("playerBullet").transform;
        
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        GameObject collisionGameObject = collision.gameObject;

        if(collisionGameObject.tag == "Enemy"){
                Debug.Log("DAMAGING ENEMY");
                
                collisionGameObject.GetComponent<AiPatrol>().TakeDamage(damage);
                AudioSource.PlayClipAtPoint(hitSource, transform.position);
                
                StartCoroutine(quickDead());
            

            quickDead();

        }if(collisionGameObject.tag == "crowBullet"){

        }if(collisionGameObject.tag == "Boss"){
                Debug.Log("DAMAGING BOSS");
                collisionGameObject.GetComponent<tempTenochAI>().TakeDamage(damage);
                AudioSource.PlayClipAtPoint(hitSource, transform.position);

                

            StartCoroutine(quickDead());

            quickDead();
        }else{
            Die();

        }
    }

    IEnumerator CountDownTimer(){

        yield return new WaitForSeconds(dieTime);

        Die();
    }

    IEnumerator quickDead(){
        yield return new WaitForSeconds(0.1f);

        Die();
    }


    void Die(){

        Instantiate(Explosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
