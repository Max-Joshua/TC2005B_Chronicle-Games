using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiator : MonoBehaviour
{
public GameObject prefab;
public float time;



    void Awake()
    {
        Transform Rhythm = GameObject.FindWithTag("Rhythm").transform; 
        transform.SetParent(Rhythm, false);

        
    }

   // Update is called once per frame
   void Update () 
   {
       if (Input.GetKeyDown(KeyCode.Space))
        {

            Destroy(Instantiate(prefab, transform), time);
            
        }

    
   }
}
