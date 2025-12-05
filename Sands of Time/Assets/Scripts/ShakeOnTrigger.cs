using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeOnTrigger : MonoBehaviour
{
    public float shakeDuration = 0.3f;
    public float shakeMagnitude = 0.2f;

    private bool triggered = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!triggered && collision.CompareTag("Player"))
        {
            triggered = true;
            StartCoroutine(ShakeCamera());
        }
    }

    private System.Collections.IEnumerator ShakeCamera()
    {
        Transform cam = Camera.main.transform;
        Vector3 originalPos = cam.localPosition;

        float time = 0f;

        while (time < shakeDuration)
        {
            float x = Random.Range(-1f, 1f) * shakeMagnitude;
            float y = Random.Range(-1f, 1f) * shakeMagnitude;

            cam.localPosition = originalPos + new Vector3(x, y, 0);

            time += Time.deltaTime;
            yield return null;
        }

        cam.localPosition = originalPos;
    }
}