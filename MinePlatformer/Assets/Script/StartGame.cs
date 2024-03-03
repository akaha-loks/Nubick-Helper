using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    private void Start()
    {
        PlayerPrefs.SetFloat("HP", 10);
    }
}
