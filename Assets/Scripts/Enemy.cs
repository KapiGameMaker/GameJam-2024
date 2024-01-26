using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    enum Weapon
    {
        Punch,
        Bone,
        Bin
    }

    public Rigidbody2D enemyRigidbody;
    public float speed;
    public float speed_cap;
    public float lifespan;

    private float currentTime = 0f;

    [SerializeField] Weapon weapon;
    string weaponType;
    // Start is called before the first frame update
    void Start()
    {
        SetUp();
    }

    // Update is called once per frame
    void Update()
    {
        enemyRigidbody.AddForce(Vector2.ClampMagnitude(new Vector2(speed, 0), speed_cap));

        currentTime += Time.deltaTime;
        if (currentTime >= lifespan)
        {
            Destroy(gameObject);
            currentTime = 0f;
        }
    }

    private void SetUp()
    {
        weaponType = weapon.ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(weaponType))
        {
            enemyRigidbody.constraints = RigidbodyConstraints2D.None;
            StartCoroutine(Death());
        }
    }

    IEnumerator Death()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
