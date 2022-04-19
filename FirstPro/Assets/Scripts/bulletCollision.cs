using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletCollision : MonoBehaviour
{
    public AudioSource hitSource;

    // Start is called before the first frame update
    void Start()
    {
        hitSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D (Collision2D collision) {
        if(collision.gameObject.tag == "Player"){
            
            Debug.Log("Bullet Impact!");
            hitSource.Play();


        }
    }
}
