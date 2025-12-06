using System.Collections;
using UnityEngine;

public class SpikeTrigger : MonoBehaviour
{
    [Header("Spike Settings")]
    public GameObject spikePrefab;
    public float riseHeight = 1f;
    public float riseSpeed = 4f;
    public int spikeDamage = 1;

    [Header("Spawn Settings")]
    public Vector3 spawnOffset;
    
    private bool triggered = false;
    private GameObject spawnedSpike;
    private Vector3 hiddenPos;
    private Vector3 upPos;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!triggered && collision.CompareTag("Player"))
        {
            triggered = true;
            SpawnAndRiseSpike();
        }
    }

    void SpawnAndRiseSpike()
    {
        Vector3 spawnPosition = transform.position + spawnOffset;

        spawnedSpike = Instantiate(spikePrefab, spawnPosition, Quaternion.identity);

        hiddenPos = spawnPosition;
        upPos = hiddenPos + new Vector3(0, riseHeight, 0);

        StartCoroutine(RiseSpike());

        SpikeHitbox hitbox = spawnedSpike.AddComponent<SpikeHitbox>();
        hitbox.damage = spikeDamage;
    }

    private IEnumerator RiseSpike()
    {
        while (spawnedSpike.transform.position.y < upPos.y - 0.01f)
        {
            spawnedSpike.transform.position =
                Vector3.MoveTowards(spawnedSpike.transform.position, upPos, riseSpeed * Time.deltaTime);

            yield return null;
        }
    }
}

public class SpikeHitbox : MonoBehaviour
{
    public int damage = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerStats stats = collision.gameObject.GetComponent<PlayerStats>();
            if (stats != null)
                stats.TakeDamage(damage);
        }
    }
}
