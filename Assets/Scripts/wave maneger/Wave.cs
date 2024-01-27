using UnityEngine;

[System.Serializable]
public struct Wave
{
    public enum Weakness
    {
        none,
        punch,
        bone,
        trash
    }

    public GameObject enemy;
    public GameObject spawnPoint;
    public float spawn_time;
    public float speed;
    public bool isRight;

    public Weakness weakness1;
    public Weakness weakness2;
}