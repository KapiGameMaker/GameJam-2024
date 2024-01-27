using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBG : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float target;


    void Update()
    {
        transform.position += new Vector3(speed * Time.deltaTime, 0);
        if (transform.position.x < -target)
        {
            transform.position = new Vector3(target * 2 -9, transform.position.y);
        }
    }
}
