using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallTriggerManager : MonoBehaviour
{
    public Rigidbody2D[] groundPieces;
    public float fallDelay = 0.2f;

    private bool hasTriggered = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!hasTriggered && collision.CompareTag("Player"))
        {
            hasTriggered = true;
            StartCoroutine(MakeGroundFall());
        }
    }

    private System.Collections.IEnumerator MakeGroundFall()
    {
        yield return new WaitForSeconds(fallDelay);

        foreach (var rb in groundPieces)
        {
            if (rb != null)
                rb.isKinematic = false;
        }
    }
}

