using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int hp = 5;
    Animator anim;
    [SerializeField] List<GameObject> heart;

    private void Start()
    {
        anim = GetComponent<Animator>();    
    }

    public void Hurt()
    {
        SoundManager.Instance.PlaySound(SoundManager.Instance.MCHit);
        anim.SetTrigger("damage");
        hp--;
        if (hp == 0)
        {
            Debug.Log("555");
            SceneManager.LoadScene("Death");
        }
        if (hp > 0)
        {
            Destroy(heart[heart.Count - 1]);
            heart.RemoveAt(heart.Count - 1);
        }
        Debug.Log(hp);
        
    }

    // play animation
}
