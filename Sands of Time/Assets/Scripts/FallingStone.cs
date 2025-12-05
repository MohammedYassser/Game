using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingStonee : MonoBehaviour
{
    public int damage = 1;
    public float destroyAfterGroundHit = 2f;
    
    private bool canDamage = false;
    private bool hasHitGround = false;

    private void Start()
    {
        StartCoroutine(EnableDamageAfterDelay(0.2f));
    }

    private IEnumerator EnableDamageAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        canDamage = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!canDamage) return; 

        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerStats playerStats = collision.gameObject.GetComponent<PlayerStats>();
            if (playerStats != null)
            {
                playerStats.TakeDamage(damage);
            }
        }

        if (!hasHitGround)
        {
            hasHitGround = true;
            Destroy(gameObject, destroyAfterGroundHit);
        }
    }
}