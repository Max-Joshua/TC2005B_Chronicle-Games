using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBullet : MonoBehaviour
{

    public float dieTime, damage;
    public GameObject die;

    // Start is called before the first frame update
    void Start(){
        StartCoroutine(CountDownTimer());
    }

    void OnCollisionEnter2D(Collision2D col) {

    Die();

    }
    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator CountDownTimer(){

        yield return new WaitForSeconds(dieTime);

        Die();
    }

    void Die(){
        Destroy(gameObject);
    }
}
