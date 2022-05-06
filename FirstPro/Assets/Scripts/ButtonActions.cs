using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* 
Chronicle Games
05/29/2022

-> Activate the retreval of data from the APItest script when the specific button is clicked

*/
public class ButtonActions : MonoBehaviour
{
    //[SerializeField] GameObject apiObject;
    //APITest api;

    [SerializeField] APITest api;

    void Start()
    {
        //api = apiObject.GetComponent<APITest>();
    }

    public void GetScores()
    {
        api.QueryTopHighScores();
    }
}
