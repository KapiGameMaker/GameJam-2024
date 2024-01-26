[System.Serializable]
public struct Wave
{
    public enum Enemy
    {
        Bird,
        Dog,
        Trash
    }

    public Enemy enemy;

    public float spawn_time;
    public float speed;
    public bool isLeft;
}