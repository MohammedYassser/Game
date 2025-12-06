using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeMoveTrigger : MonoBehaviour
{
    public Transform spike;        
    public float moveDistance = 1f; 
    private bool triggered = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!triggered && collision.CompareTag("Player"))
        {
            triggered = true;

            float playerX = collision.transform.position.x;
            float spikeX = spike.position.x;

            float direction = Mathf.Sign(playerX - spikeX);

            spike.position += new Vector3(moveDistance * direction, 0, 0);
        }
    }
}
