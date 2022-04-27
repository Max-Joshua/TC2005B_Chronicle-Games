using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* 
Chronicle Games
04/10/2022

Enemy bullet attributes and behaviour

->When the bullet is created the timer "CountDownTimer" will get trigger, which will
determine the lifespan of the bullet if it does not collide with either a wall or a Player,
if it does, the bullet will be destroyed.

*/
public class enemyBullet : MonoBehaviour
{

    Player player;
    public float dieTime;
    public int damage;
    public GameObject die;
    public AudioClip hitSource;
    public GameObject HitScreen;
    public GameObject playerPos;

    // Start is called before the first frame update
    void Start(){
        StartCoroutine(CountDownTimer());                                   //Lifespan timer begins
        Transform Bullet = GameObject.FindWithTag("crowBullet").transform;

    }

    private void OnCollisionEnter2D(Collision2D collision) {
        GameObject collisionGameObject = collision.gameObject;

        if(collisionGameObject.tag == "Player"){ 

            if(collisionGameObject.GetComponent<Player>() != null){
                
                collisionGameObject.GetComponent<Player>().TakeDamage(damage);
                CinemachineShake.Instance.ShakeCamera(2F, .2F);

                GameObject newHitScreen = Instantiate(HitScreen, collisionGameObject.transform.position, Quaternion.identity);
                newHitScreen.transform.parent = gameObject.transform;

                AudioSource.PlayClipAtPoint(hitSource, transform.position);
            }
            
            StartCoroutine(quickDead());
            StartCoroutine(deadScreen());


            quickDead();
            deadScreen();
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

    IEnumerator deadScreen(){
        yield return new WaitForSeconds(1f);

        Destroy(HitScreen);
    }

    void Die(){
        Destroy(gameObject);
    }
}
