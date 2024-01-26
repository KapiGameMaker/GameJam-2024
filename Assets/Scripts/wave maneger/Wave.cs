[System.Serializable]
public struct Wave
{
    // Declares the Mobs enum type.
    public enum Mobs
    {
        Goblin,
        Slime,
        Bat
    }

    public Mobs mobs; // What kind of enemy should be spawned in this wave?
    public float spawn_time;
    public float spawn_rate;
    public float speed;
}