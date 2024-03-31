using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLvL : MonoBehaviour
{
    public int lvl;

    private void Update()
    {
        lvl = PlayerPrefs.GetInt("lvl");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            UI_.NextLevel();
            lvl += 1;
            PlayerPrefs.SetInt("lvl", lvl);
        }
    }
}
