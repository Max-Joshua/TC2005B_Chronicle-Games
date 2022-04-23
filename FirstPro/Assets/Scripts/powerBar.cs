using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class powerBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxPower(int powerPoints)
    {
        slider.maxValue = powerPoints;
        slider.value = powerPoints;
    }

    public void SetPowerPoints(int powerPoints)
    {
        slider.value = powerPoints;
    }
}
