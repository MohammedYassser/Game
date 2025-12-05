using System.Collections;
using UnityEngine;

public class TempleHazardTrigger : MonoBehaviour
{
    public float shakeDuration = 0.3f;
    public float shakeMagnitude = 0.2f;
    public float forwardDistance = 2f; 
    public GameObject stonePrefab;
    public float spawnHeight = 6f;

    private bool triggered = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!triggered && collision.CompareTag("Player"))
        {
            triggered = true;
            StartCoroutine(ShakeCamera());
            SpawnStoneAbovePlayer(collision.transform);
        }
    }

    private void SpawnStoneAbovePlayer(Transform player)
    {
        if (stonePrefab == null)
        {
            Debug.LogError("Stone Prefab not assigned!");
            return;
        }

        float facing = Mathf.Sign(player.localScale.x);
        if (facing == 0) facing = 1;

        Vector3 spawnPos = player.position + 
            new Vector3(forwardDistance * facing, spawnHeight, 0);

        Instantiate(stonePrefab, spawnPos, Quaternion.identity);
    }

    private IEnumerator ShakeCamera()
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