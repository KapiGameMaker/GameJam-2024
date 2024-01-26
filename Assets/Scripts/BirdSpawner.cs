using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSpawner : MonoBehaviour
{
    public float spawn_rate;
    public GameObject bird_prefab;

    public float speed;
    public float speed_cap;

    // Start is called before the first frame update
    void Start()
    {  
        GameObject bird = Instantiate(bird_prefab, this.transform);
        Enemy set = bird.GetComponent<Enemy>();
        set.speed = speed;
        set.speed_cap = speed_cap;

    }

    // Update is called once per frame
    void Update()
    {

    }
}
