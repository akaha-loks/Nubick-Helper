using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blaze : MonoBehaviour
{
    public float speed = 4;
    public float angrySpeed = 6;
    public float chillSpeed = 4;
    public int enemyHP = 3;
    public GameObject destroyEffect;

    public int positionOfPatrol = 5;
    public Transform point;

    bool movingRight;

    Transform player;
    public float stoppingDistance = 10;

    bool chill = false;
    bool angry = false;
    bool goBack = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        if (enemyHP <= 0)
        {
            Instantiate(destroyEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        if (Vector2.Distance(transform.position, point.position) < positionOfPatrol && angry == false)
        {
            chill = true;
        }

        if (Vector2.Distance(transform.position, player.position) < stoppingDistance)
        {
            angry = true;
            chill = false;
            goBack = false;
        }
        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            goBack = true;
            angry = false;
        }
        if (chill == true)
        {
            Chill();
        }
        else if (angry == true)
        {
            Angry();
        }
        else if (goBack == true)
        {
            GoBack();
        }
    }
    private void Chill()
    {
        if (transform.position.x > point.position.x + positionOfPatrol)
        {
            movingRight = false;
        }
        else if (transform.position.x < point.position.x - positionOfPatrol)
        {
            movingRight = true;
        }
        if (movingRight)
        {
            transform.position = new Vector2(transform.position.x + Time.deltaTime, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - Time.deltaTime, transform.position.y);
        }
    }
    private void Angry()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        speed = angrySpeed;
    }
    private void GoBack()
    {
        transform.position = Vector2.MoveTowards(transform.position, point.position, speed * Time.deltaTime);
        speed = chillSpeed;
    }
    public void TakeDamage(int damage)
    {
        enemyHP -= damage;
    }
}
