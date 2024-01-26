using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave_Maneger : MonoBehaviour
{

    public Wave[] wave;

    void Start()
    {
        Debug.Log(wave.Length);
        Debug.Log(wave[0].speed);
        Debug.Log(wave[0].enemy);
        Debug.Log(wave[1].enemy);
        Debug.Log(wave[2].enemy);
    }
}