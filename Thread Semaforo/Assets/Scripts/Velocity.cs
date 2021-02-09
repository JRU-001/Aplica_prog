using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Velocity : MonoBehaviour
{

    public SliderTimer slider;
    public Slider sli;

    public void Slow()
    {
        slider.timer = 0.5f;
        sli.value = slider.timer;
    }

    public void Normal()
    {
        slider.timer = 1;
        sli.value = slider.timer;
    }

    public void Fast()
    {
        slider.timer =3f;
        sli.value = slider.timer;
    }
}
