using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StepProgress : MonoBehaviour
{
    public Slider slider;

    public void setMaxSteps(int steps)
    {
        slider.maxValue = steps;
        slider.value = 0;
    }

    public void SetSteps(int steps)
    {
        slider.value = steps;
    }
}
