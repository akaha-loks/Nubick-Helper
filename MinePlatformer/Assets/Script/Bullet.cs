using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float distance;
    public int damage;
    public GameObject destroyEffect;

    private void Update()
    {
        RaycastHit2D other = Physics2D.Raycast(transform.position, transform.up, distance);
        if (other.collider != null)
        {
            if (other.collider.CompareTag("Blaze"))
            {
                other.collider.GetComponent<Blaze>().TakeDamage(damage);
                Destroy();
            }
            if (other.collider.CompareTag("Zombie"))
            {
                other.collider.GetComponent<Zombie>().TakeDamage(damage);
                Destroy();
            }
            if (other.collider.CompareTag("Skelet"))
            {
                other.collider.GetComponent<Skelet>().TakeDamage(damage);
                Destroy();
            }
            if (other.collider.CompareTag("Ground"))
            {
                Destroy();
            }
        }
        transform.Translate(Vector2.up * speed * Time.deltaTime);
        Destroy(gameObject, 0.5f);
    }

    private void Destroy()
    {
        Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

}
