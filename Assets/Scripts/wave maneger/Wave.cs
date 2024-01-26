using UnityEngine;

[System.Serializable]
public struct Wave
{
    public GameObject enemy;
    public GameObject spawnPoint;
    public float spawn_time;
    public float speed;
    public bool isLeft;
}