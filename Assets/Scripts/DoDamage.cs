using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoDamage : MonoBehaviour
{
    [SerializeField] Sprite birdBullet;
    Player player;
    bool isAlreadyAttack = false;

    private void Start()
    {
        player = GameObject.Find("MC").GetComponent<Player>();
    }

    private void Update()
    {
        tranformCheck();
    }

    private void tranformCheck()
    {
        if (transform.position.x >= -0.5f && transform.position.x <= 0.5f && !isAlreadyAttack)
        {
            Attack();
        }
    }
    private void Attack()
    {
        player.Hurt();
        if(gameObject.name == "Bird")
        {
            spawnBullet();
        }
        GetComponent<Enemy>().DoDeath();
        isAlreadyAttack = true;
    }

    private void spawnBullet()
    {
        Instantiate(birdBullet, new Vector3(0, transform.position.y, 0), new Quaternion(0, 0, 0, 0));
    }
}
