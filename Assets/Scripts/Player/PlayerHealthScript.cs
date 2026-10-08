using UnityEngine;

public class PlayerHealthScript : MonoBehaviour
{
    public int maxPlayerhealth = 6;
    public int playerhealth;

    public PlayerMovement PM;
    public GameUIManager GUIM;

    public int MaxPlayerLives;
    public int PLives;

    public bool IsDead;

    public Transform RespawnPoint;

    private void Awake()
    {
        IsDead = false;
        MaxPlayerLives = SettingsManager.PlayerLives;
        PLives = MaxPlayerLives;

        playerhealth = maxPlayerhealth;
        GUIM = FindAnyObjectByType<GameUIManager>();
        PM = FindAnyObjectByType<PlayerMovement>();
    }

    private void FixedUpdate()
    {
        if (playerhealth <= 0 && !IsDead)
        {
            IsDead = true;
            DeathScreen();
        }
        else if (playerhealth > 0)
        {
            IsDead = false;
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

    public void DeathScreen()
    {
        GUIM.OpenDeathScreenUi();
    }
}
