using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_ : MonoBehaviour
{
    private int saveLvl;
    private string[] lvlsName = {"TutuorLvl","Lvl2", "Lvl3", "Lvl4"};
    private void Start()
    {
        saveLvl = PlayerPrefs.GetInt("Level");
        if(saveLvl == 0)
        {
            PlayerPrefs.SetFloat("HP", 10);
        }
    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.R)) 
        {
            PlayerPrefs.DeleteKey("Level");
            Debug.Log("Resset");
        }
    }
    public void LoadScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }
    public void LoadSceneName()
    {
        SceneManager.LoadScene(lvlsName[saveLvl]);
    }
    public static void NextLevel()
    {
        var index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index + 1);
    }
    public void PlayGame()
    {
        Time.timeScale = 1;
    }
}
