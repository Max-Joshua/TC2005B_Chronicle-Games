using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
/* 
Chronicle Games
04/22/2022

-> Controlls the score text value.

*/
public class Score : MonoBehaviour
{
    public static int scoreValue;
    Text score;

    void Start()
    {
        score = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Score: " + scoreValue;
    }
}
