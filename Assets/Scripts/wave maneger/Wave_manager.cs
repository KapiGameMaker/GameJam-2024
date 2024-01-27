using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave_Maneger : MonoBehaviour
{
    private float currentTime = 0;

    public List<Wave> wave;

    void Update()
    {
        currentTime += Time.deltaTime;

        for (int i = 0; i < wave.Count; i++)
        {
            if (currentTime >= wave[i].spawn_time)
            {
                GameObject enemy = Instantiate(wave[i].enemy, wave[i].spawnPoint.transform);
                Enemy set = enemy.GetComponent<Enemy>();
                if (wave[i].isRight)
                {
                    set.speed *= -1;
                }
                set.speed_cap = wave[i].speed;
                wave.Remove(wave[i]);
            }
        }  
    }
}