using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Wave_Maneger : MonoBehaviour
{
    public float currentTime = 0;

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
                set.weakness1 = wave[i].weakness1.ToString();
                set.weakness2 = wave[i].weakness2.ToString();
                if (wave[i].isRight)
                {
                    enemy.transform.localScale = new Vector3(-1, 1, 1);
                    set.speed *= -1;
                }
                set.speed_cap = wave[i].speed;
                wave.Remove(wave[i]);
            }
        }

        EndGame();
    }

    private void EndGame()
    {
        if (currentTime >= 180 || Input.GetKeyDown(KeyCode.P))
        {
            SceneManager.LoadScene("CutScene3");
        }
    }
}