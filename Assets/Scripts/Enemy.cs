using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Enemy : MonoBehaviour
{

    [SerializeField] AudioClip hit;

    public Rigidbody2D enemyRigidbody;
    public float speed;
    public float speed_cap;
    public bool alive = true;

    public GameObject punch_Icon;
    public GameObject bone_Icon;
    public GameObject bin_Icon;

    public string weakness1;
    public string weakness2;
    bool isWeakness1hit = false;
    bool isWeakness2hit = false;

    [SerializeField] Transform bar;

    [SerializeField] GameObject weaknessIcon1;
    [SerializeField] GameObject weaknessIcon2;
    private GameObject slot1;
    private GameObject slot2;
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
        if(weakness2 == "None") { isWeakness2hit = true; }

        bar = transform.Find("Canvas").transform.Find("bar");
        if (weakness1 != "None") 
        {
            weaknessIcon1 = SetIcon(weakness1);
            slot1 = Instantiate(weaknessIcon1, bar);
        }
        if (weakness2 != "None")
        {
            weaknessIcon2 = SetIcon(weakness2);
            slot2 = Instantiate(weaknessIcon2, bar);
        }
    }

    private GameObject SetIcon(string name)
    {
        switch (name)
        {
            case "Punch":
                return punch_Icon;
            case "Bone":
                return bone_Icon;
            case "Bin":
                return bin_Icon;
            default:
                return null;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(weakness1) && !isWeakness1hit)
        {
            isWeakness1hit = true;
            SoundManager.Instance.PlaySound(SoundManager.Instance.Hit);
            Destroy(slot1);
        }

        if (collision.gameObject.CompareTag(weakness2) && !isWeakness2hit)
        {
            isWeakness2hit = true;
            SoundManager.Instance.PlaySound(SoundManager.Instance.Hit);
            Destroy(slot2);
        }

        if (isWeakness1hit && isWeakness2hit)
        {
            enemyRigidbody.constraints = RigidbodyConstraints2D.None;
            StartCoroutine(Death());
        }
    }

    public void DoDeath()
    {
        StartCoroutine(Death());
    }

    IEnumerator Death()
    {
        alive = false;
        enemyRigidbody.constraints = RigidbodyConstraints2D.None;
        GetComponent<Collider2D>().isTrigger = true;
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
