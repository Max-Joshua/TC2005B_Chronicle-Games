using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        
        StartCoroutine(CountDownTimer());
        Transform Bullet = GameObject.FindWithTag("crowBullet").transform;

    
        
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        GameObject collisionGameObject = collision.gameObject;

        if(collisionGameObject.tag == "Player"){

            
            Debug.Log("NRUDFJFFFFFFF");

            if(collisionGameObject.GetComponent<Player>() != null){
                
                collisionGameObject.GetComponent<Player>().TakeDamage(damage);
                CinemachineShake.Instance.ShakeCamera(5F, .2F);

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
