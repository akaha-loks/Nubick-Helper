using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDamage : MonoBehaviour
{
    private bool Un;
    private float HP;
    [SerializeField] private float[] damage = {1, 2, 3};

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip sound;

    private void Update()
    {
        HP = PlayerPrefs.GetFloat("HP");
        if(HP < 0)
        {
            SceneManager.LoadScene("Restart");
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
            audioSource.PlayOneShot(sound, 1f);
            Invoke("UnSec", 0.5f);
        }
        if (collision.gameObject.tag == "Blaze" && Un == false)
        {
            HP -= damage[0];
            PlayerPrefs.SetFloat("HP", HP);
            Un = true;
            audioSource.PlayOneShot(sound, 1f);
            Invoke("UnSec", 0.5f);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Arrow" && Un == false)
        {
            HP -= damage[2];
            PlayerPrefs.SetFloat("HP", HP);
            Un = true;
            audioSource.PlayOneShot(sound, 1f);
            Destroy(collision.gameObject);
            Invoke("UnSec", 0.5f);
        }
        if (collision.gameObject.tag == "Traps")
        {
            HP -= HP + 1;
            PlayerPrefs.SetFloat("HP", HP);
            Un = true;
            audioSource.PlayOneShot(sound, 1f);
        }
    }
}
