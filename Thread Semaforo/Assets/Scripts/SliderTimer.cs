using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderTimer : MonoBehaviour
{
    public float timer;
    public Slider slider;

    private void Start()
    {
        timer = 1;
        slider.value = timer;
    }

    public void SlideTime(float speed)
    {
        timer = speed;
    }
}
