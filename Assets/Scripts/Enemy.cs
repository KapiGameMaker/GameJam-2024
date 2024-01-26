using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Rigidbody2D enemyRigidbody;
    public float speed;
    public float speed_cap;
    public float lifespan;

    private float currentTime = 0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        enemyRigidbody.AddForce(Vector2.ClampMagnitude(new Vector2(speed, 0), speed_cap));

        currentTime += Time.deltaTime;
        if (currentTime >= lifespan)
        {
            Destroy(gameObject);
            currentTime = 0f;
        }
    }
}
