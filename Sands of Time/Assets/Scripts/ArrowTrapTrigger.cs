using UnityEngine;

public class ArrowTrapTrigger : MonoBehaviour
{
    public GameObject arrowPrefab;   
    public Transform spawnPoint;      
    public int arrowsToSpawn = 3;     
    public float timeBetweenShots = 0.4f;

    private bool triggered = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!triggered && collision.CompareTag("Player"))
        {
            triggered = true;
            StartCoroutine(ShootArrows(collision.transform));
        }
    }

    private System.Collections.IEnumerator ShootArrows(Transform player)
    {
        for (int i = 0; i < arrowsToSpawn; i++)
        {
            GameObject arrow = Instantiate(arrowPrefab, spawnPoint.position, Quaternion.identity);

            Vector2 direction = (player.position - spawnPoint.position).normalized;

            arrow.GetComponent<Arrow>().Launch(direction);

            yield return new WaitForSeconds(timeBetweenShots);
        }
    }
}
