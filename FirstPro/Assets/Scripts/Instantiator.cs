using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiator : MonoBehaviour
{
public GameObject prefab;
public float time_del;

public float Timer;



    void Start()
    {


        Transform Rhythm = GameObject.FindWithTag("Rhythm").transform; 
        
        transform.SetParent(Rhythm, false);
        
    

        
    }

   // Update is called once per frame
   void Update () 
   {

       
       CreateBar();
    
   }


    public void CreateBar ()
    {


        Timer -= Time.deltaTime;

       

       if (Timer <= 0f)
        {
            
            GameObject Bar = Instantiate(prefab, transform);

            Destroy(Bar, time_del);

            Timer = 60f/70f;
            
        }


    }


}
