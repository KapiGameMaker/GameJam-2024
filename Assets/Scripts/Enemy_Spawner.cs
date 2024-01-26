using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawner : MonoBehaviour
{
    public float spawn_rate;
    public GameObject enemy_prefab;

    [HideInInspector] public float speed;
    public float speed_cap;
    public float lifespan;

    private float currentTime = 0f;
    [SerializeField] bool isRight;

    // Start is called before the first frame update
    void Start()
    {
        setUp();
        GameObject bird = Instantiate(enemy_prefab, this.transform);
        Enemy set = bird.GetComponent<Enemy>();
        set.speed = speed;
        set.speed_cap = speed_cap;
        set.lifespan = lifespan;

    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= spawn_rate)
        {
            Spawn_Enemy();
            currentTime = 0f;
        }
    }

    void Spawn_Enemy()
    {
        GameObject bird = Instantiate(enemy_prefab, this.transform);
        Enemy set = bird.GetComponent<Enemy>();
        set.speed = speed;
        set.speed_cap = speed_cap;
    }

    void setUp()
    {
        if (isRight)
        {
            speed = 1000;
        }
        else speed = -1000;
    }
}
