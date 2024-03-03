using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float offset;
    private float time;
    public float startTime;

    public GameObject bullet;
    public Transform point;

    private void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotateZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f,0f,rotateZ + offset);

        if(time <= 0f)
        {
            if(Input.GetMouseButtonDown(0))
            {
                Instantiate(bullet, point.position, transform.rotation);
                time = startTime;
            }
        }
        else
        {
            time -= Time.deltaTime;
        }
    }
}
