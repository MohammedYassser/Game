using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingStone : MonoBehaviour
{
    public int damage = 1; 

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            PlayerStats playerStats = collision.gameObject.GetComponent<PlayerStats>();
            if(playerStats != null)
            {
                playerStats.TakeDamage(damage);
            }
        }
        Destroy(gameObject);
    }
}
