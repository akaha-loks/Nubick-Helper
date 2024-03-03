using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP : MonoBehaviour
{
    public float HPpl = 10f;
    [SerializeField] private float maxHP = 10f;
    [SerializeField] Image bar;

    private void Update()
    {
        HPpl = PlayerPrefs.GetFloat("HP");
        bar.fillAmount = HPpl / maxHP;
    }

}
