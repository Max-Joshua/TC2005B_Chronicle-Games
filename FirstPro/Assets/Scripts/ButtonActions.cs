using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        api.QueryScores();
    }
}
