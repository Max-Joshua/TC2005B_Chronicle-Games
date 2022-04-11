using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiator : MonoBehaviour
{
public GameObject prefab;
public float time_del;

public float Timer;



    void Awake()
    {
        Transform Rhythm = GameObject.FindWithTag("Rhythm").transform; 
        transform.SetParent(Rhythm, false);

        
    }

   // Update is called once per frame
   void Update () 
   {

       Timer -= Time.deltaTime;

       if (Timer <= 0f)
        {

            Destroy(Instantiate(prefab, transform), time_del);

            Timer = .5f;
            
        }

    
   }
}
