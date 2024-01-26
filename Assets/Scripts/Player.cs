using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int hp = 3; 

    public void Hurt()
    {
        hp--;
        Debug.Log(hp);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            this.Hurt();
            Destroy(collision.gameObject);
        }
    }

    // play animation
}
