using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain : MonoBehaviour
{
   
    // Update is called once per frame
    void Update()
    {
                //Left Right Movement
        if (Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.A)) 
        {
            
            gameObject.transform.localScale = new Vector3((float)-1.5, 1, 1);
            
        }

    }
}
