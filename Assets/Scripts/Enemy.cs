using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] AudioClip hit;

    public Rigidbody2D enemyRigidbody;
    public float speed;
    public float speed_cap;

    public string weakness1;
    public string weakness2;
    bool isWeakness1hit = false;
    bool isWeakness2hit = false;

    // Start is called before the first frame update
    void Start()
    {
        SetUp();
    }

    // Update is called once per frame
    void Update()
    {
        enemyRigidbody.AddForce(Vector2.ClampMagnitude(new Vector2(speed, 0), speed_cap));
    }

    private void SetUp()
    {
        if(weakness1 == "None") { isWeakness1hit = true; }
        if (weakness2 == "None") { isWeakness2hit = true; }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(weakness1))
        {
            isWeakness1hit=true;
        }

        if (collision.gameObject.CompareTag(weakness2))
        {
            isWeakness2hit = true;
        }

        if(isWeakness1hit && isWeakness2hit)
        {
            enemyRigidbody.constraints = RigidbodyConstraints2D.None;
            StartCoroutine(Death());
        }
    }

    IEnumerator Death()
    {
        SoundManager.Instance.PlaySound(SoundManager.Instance.Hit);
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
