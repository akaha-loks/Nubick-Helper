using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDamage : MonoBehaviour
{
    private bool Un;
    private float HP;
    [SerializeField] private float[] damage = {1, 2, 3};

    private void Update()
    {
        HP = PlayerPrefs.GetFloat("HP");
        if(HP < 0)
        {
            SceneManager.LoadScene(0);
        }
    }
    public void UnSec()
    {
        Un = false;
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Zombie" && Un == false)
        {
            HP -= damage[1];
            PlayerPrefs.SetFloat("HP", HP);
            Un = true;
            Invoke("UnSec", 0.5f);
        }
        if (collision.gameObject.tag == "Blaze" && Un == false)
        {
            HP -= damage[0];
            PlayerPrefs.SetFloat("HP", HP);
            Un = true;
            Invoke("UnSec", 0.5f);
        }
    }
}
