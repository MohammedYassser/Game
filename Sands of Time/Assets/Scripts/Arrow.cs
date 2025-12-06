using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speed = 10f;
    public int damage = 1;

    private Vector2 moveDirection;
    private Vector3 initialScale;

    void Awake()
    {
        initialScale = transform.localScale;
    }

    public void Launch(Vector2 direction)
    {
        direction.y = 0;
        moveDirection = direction.normalized;

        if (moveDirection.x < 0f)
            transform.localScale = new Vector3(-Mathf.Abs(initialScale.x), initialScale.y, initialScale.z);
        else if (moveDirection.x > 0f)
            transform.localScale = new Vector3(Mathf.Abs(initialScale.x), initialScale.y, initialScale.z);
    }

    private void Update()
    {
        transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerStats stats = collision.GetComponent<PlayerStats>();
            if (stats != null)
            {
                stats.TakeDamage(damage);
            }
        }

        Destroy(gameObject);
    }
}
