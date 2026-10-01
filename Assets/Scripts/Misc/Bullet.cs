using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public int bulletDamage;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            if (collision.TryGetComponent(out EnemyHealth enemyHealth))
            {
                enemyHealth.TakeDamage(bulletDamage);
                Destroy(gameObject);
            }
        }
    }
}
