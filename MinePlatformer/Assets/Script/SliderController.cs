using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    private Slider slider;
    public float oldVolume;

    private void Start()
    {
        slider = GetComponent<Slider>();
        oldVolume = slider.value;
        if (!PlayerPrefs.HasKey("volume")) slider.value = 1;
        else slider.value = PlayerPrefs.GetFloat("volume");
    }
    private void Update()
    {
        if (oldVolume != slider.value)
        {
            PlayerPrefs.SetInt("audioTrue", 1);
            PlayerPrefs.SetFloat("volume", slider.value);
            PlayerPrefs.Save();
            oldVolume = slider.value;
        }
    }
}
