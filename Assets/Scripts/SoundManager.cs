using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioClip BG1;
    [SerializeField] AudioClip BG2;
    public AudioClip Grab;
    public AudioClip Hit;
    public AudioClip thrown;
    public AudioClip MCHit;


    // Singleton pattern to ensure only one instance exists
    private static SoundManager _instance;
    public static SoundManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<SoundManager>();

                if (_instance == null)
                {
                    GameObject soundManagerObject = new GameObject("SoundManager");
                    _instance = soundManagerObject.AddComponent<SoundManager>();
                }
            }

            return _instance;
        }
    }

    public AudioSource audioSource;

    void Awake()
    {
        // Ensure only one instance of SoundManager exists
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        // Create an AudioSource component if not attached
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    private void Start()
    {
        audioSource.volume = 0.1f;
        StartCoroutine(BG_Song());
    }

    // Play a sound
    public void PlaySound(AudioClip soundClip)
    {
        audioSource.PlayOneShot(soundClip);
    }

    // Stop the currently playing sound
    public void StopSound()
    {
        audioSource.Stop();
    }

    IEnumerator BG_Song()
    {
        audioSource.clip = BG1;
        audioSource.Play();
        yield return new WaitForSeconds(BG1.length);
        audioSource.clip = BG2;
        audioSource.Play();
        yield return new WaitForSeconds(BG2.length);
        audioSource.Stop();
        // Song has ended, play the next one
    }
}
