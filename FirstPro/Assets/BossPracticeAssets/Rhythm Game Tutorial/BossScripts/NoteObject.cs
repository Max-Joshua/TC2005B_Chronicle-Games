using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{

    public GameObject hitEffect, goodEffect, perfectEffect, missEffect;

    public bool canBePressed;

    public KeyCode keyToPress; 


    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(keyToPress))
        {
            if(canBePressed)
            {


                gameObject.SetActive(false);

                if(Mathf.Abs(transform.position.y) > 0.25f)
                {
                    GameManager.instance.NormalHit();
                    // Debug.Log("Normal");
                    Instantiate(hitEffect, transform.position , hitEffect.transform.rotation);
                }
                else if (Mathf.Abs(transform.position.y) > 0.05f)
                {
                    GameManager.instance.GoodHit();
                     // Debug.Log("Good");
                     Instantiate(goodEffect, transform.position, goodEffect.transform.rotation);
                }
                else
                {
                    GameManager.instance.PerfectHit();
                     //Debug.Log("Perfect");
                    Instantiate(perfectEffect, transform.position, perfectEffect.transform.rotation);
                }
            }

             
        }

        DestroyNote();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Activator")
        {
            canBePressed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Activator" && gameObject.activeSelf)
        {
            canBePressed = false;

            GameManager.instance.NoteMissed();
            Instantiate(missEffect, transform.position, missEffect.transform.rotation);
            
        }
    }


    void DestroyNote()
    {
        if(transform.position.y < -2)
            {
                Destroy(gameObject);
            }
    }
}
