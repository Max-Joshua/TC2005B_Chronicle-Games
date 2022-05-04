using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/* 
Chronicle Games
04/22/2022

-> Sets player's power attributes.

*/
public class powerBar : MonoBehaviour
{
    Player player;
    public Slider slider;
    public Animator powerAnimation;

    public void SetMaxPower(int powerPoints)
    {
        slider.maxValue = powerPoints;
        slider.value = powerPoints;
    }

    public void SetPowerPoints(int powerPoints)
    {
        powerAnimation.SetInteger("pwerLevel", powerPoints);
        slider.value = powerPoints;

    }

    void Start() {

    powerAnimation = GetComponentInChildren<Animator>();

    }

}
