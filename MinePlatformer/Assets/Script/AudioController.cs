using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    private AudioSource audio_;

    private void Start()
    {
        audio_ = GetComponent<AudioSource>();
        if (!PlayerPrefs.HasKey("volume")) audio_.volume = 1;
    }
    private void Update()
    {
        audio_.volume = PlayerPrefs.GetFloat("volume");
    }
}