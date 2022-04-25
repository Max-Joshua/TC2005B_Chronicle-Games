using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiator : MonoBehaviour
{
public GameObject prefab;
public float time_del;
public float beat; 
public float firstBeat;


public float Timer;

    void Start()
    {
        Transform Rhythm = GameObject.FindWithTag("Rhythm").transform;  
        transform.SetParent(Rhythm, false);  
        /*StartCoroutine(CreateBar());*/
    }

   // Update is called once per frame
   void Update () 
   {   
       CreateBar();
   }

/*public void FirstBar()
    {
    Timer -= Time.deltaTime;

       if (Timer == 0f){  
            GameObject Bar = Instantiate(prefab, transform);
            Destroy(Bar, time_del);
            
        }
    } */

//Original Func

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


/*
    IEnumerator CreateBar(){

        yield return new WaitForSeconds(beat);

        GameObject Bar = Instantiate(prefab, transform);
    } */
/*
    IEnumerator FirstBar(){
        yield return new WaitForSeconds(firstBeat);

        GameObject Bar = Instantiate(prefab, transform);
        StartCoroutine(CreateBar());
        
    } */
    /*void DestroyBar(){
        Destroy(Bar);
    }*/

}