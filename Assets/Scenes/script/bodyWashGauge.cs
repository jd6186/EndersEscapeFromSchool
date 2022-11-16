using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bodyWashGauge : MonoBehaviour
{
    public Slider TimeSlider;
    public float myMaxTime = 100;

    void Start()
    {
        this.TimeSlider = gameObject.GetComponent<Slider>();
        this.SetMaxTime(this.myMaxTime);

    }

    public void SetMaxTime(float time)
    {
        this.TimeSlider.maxValue = time;
        this.TimeSlider.value = time;
    }

    public void SetTime(float time)
    {
        this.TimeSlider.value = time;
    }
}
