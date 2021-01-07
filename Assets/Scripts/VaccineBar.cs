using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VaccineBar : MonoBehaviour
{
    public Slider VaccineSlider;

    public void setMaxKnowledge(int maxKnowledge)
    {
        VaccineSlider.maxValue = maxKnowledge;
    }

    public void setKnowledge(int knowledge)
    {
        VaccineSlider.value = knowledge;
    }

    public float getKnowledge()
    {
        return VaccineSlider.value;
    }
}
