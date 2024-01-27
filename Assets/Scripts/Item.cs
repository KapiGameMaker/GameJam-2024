using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Item : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    [SerializeField] Sprite ArtSlot;
    [SerializeField] Sprite ArtGrab;
    [SerializeField] Transform target;
    [SerializeField] float lerpDuration = 1f;
    public bool pickState;
    public float currentTime = 0f;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        UpdateTimeCounter();
        if (pickState && currentTime >= 1f)
        {
            ReturnItemToSlot();
        }
    }

    void UpdateTimeCounter()
    {
        if (pickState)
        {
            currentTime += Time.deltaTime;
        }
        else currentTime = 0;
    }

    // Method to handle the event when pickState is true for 3 seconds
    void ReturnItemToSlot()
    {
        StartCoroutine(LerpToTarget(target.position, lerpDuration));
        currentTime = 0f;
        pickState = false;
    }

    IEnumerator LerpToTarget(Vector3 targetPosition, float duration)
    {
        float elapsedTime = 0f;
        Vector3 initialPosition = transform.position;

        while (elapsedTime < duration)
        {
            transform.position = Vector3.Lerp(initialPosition, targetPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure that the final position is exactly the target position
        transform.position = targetPosition;
        transform.rotation = Quaternion.Euler(Vector3.zero);
        gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        SlotArt();
    }

    public void SlotArt()
    {
        spriteRenderer.sprite = ArtSlot;
    }

    public void GrabArt()
    {
        spriteRenderer.sprite = ArtGrab;
    }
}
