using UnityEngine;

public class PlayerHealthScript : MonoBehaviour
{
    public int maxPlayerhealth = 6;
    public int playerhealth;

    public PlayerMovement PM;

    private void Awake()
    {
        playerhealth = maxPlayerhealth;
        PM = FindAnyObjectByType<PlayerMovement>();
    }

    private void FixedUpdate()
    {
        if (playerhealth <= 0)
        {
            Destroy(this.gameObject);
            // later on add a continue screen
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("on trigger entered");
        if (collision.gameObject.tag == "ZombieAttack")
        {
            Debug.Log("collided with enemy attack box");
            TakeDamage(collision.gameObject.GetComponent<EnemyDamageScript>().damage);
        }
        if (collision.tag == "Death")
        {
            TakeDamage(playerhealth);
        }
    }

    public void TakeDamage(int damage)
    {
        playerhealth -= damage;
    }
}
