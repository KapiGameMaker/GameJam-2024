using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int hp = 3;
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();    
    }

    public void Hurt()
    {
        anim.SetTrigger("damage");
        hp--;
        Debug.Log(hp);
    }

    // play animation
}
