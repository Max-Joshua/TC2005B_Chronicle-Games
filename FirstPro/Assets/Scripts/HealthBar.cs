using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/* 
Chronicle Games
04/05/2022

->Sets player's health attributes

*/
public class HealthBar : MonoBehaviour
{

    public Slider slider;

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHeatlh(int health)
    {
        slider.value = health;
    }
}
