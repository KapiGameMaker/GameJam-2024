using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawner : MonoBehaviour
{
    public float spawn_rate;
    public GameObject bird_prefab;

    public float speed;
    public float speed_cap;
    public float lifespan;

    private float currentTime = 0f;

    // Start is called before the first frame update
    void Start()
    {  
        GameObject bird = Instantiate(bird_prefab, this.transform);
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
        GameObject bird = Instantiate(bird_prefab, this.transform);
        Enemy set = bird.GetComponent<Enemy>();
        set.speed = speed;
        set.speed_cap = speed_cap;
    }
}
