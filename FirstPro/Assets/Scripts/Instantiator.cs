using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* 
Chronicle Games
04/04/2022

-> Creates the "Rhythm Bar" according to the songs BPM


*/
public class Instantiator : MonoBehaviour
{
public GameObject prefab;
public float time_del;
public float beat; 
public float firstBeat;

public float numOfLines;


public float Timer;
public float BPM;

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

    public void CreateBar()
    {
        Timer -= Time.deltaTime;

       if (Timer <= 0f)
        {  
            GameObject Bar = Instantiate(prefab, transform);
            numOfLines += 1;
            Destroy(Bar, time_del);
            Timer = BPM/60;
        }
    }  

}