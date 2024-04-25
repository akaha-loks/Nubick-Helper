using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public bool isMainMenu = true;
    
    private void Awake()
    {
        if (isMainMenu == false)
        {
            if (PlayerPrefs.GetFloat("HP") < 1)
            {
                PlayerPrefs.SetFloat("HP", 1);
            }
            Invoke("GetStartGame", 0.1f);
        }
        else
        {
            Time.timeScale = 1;
            if (PlayerPrefs.GetInt("audioTrue") == 0)
            {
                PlayerPrefs.SetFloat("volume", 1);
            }
        }
    }
    private void GetStartGame()
    {
        Time.timeScale = 0;
    }
}
