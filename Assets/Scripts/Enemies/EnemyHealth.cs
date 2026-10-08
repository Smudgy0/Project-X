using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public ScoreSystem scoreSystem;
    public EnemyStats EnemyType;
    public int MyHealth;

    private void Awake()
    {
        MyHealth = EnemyType.health;
        scoreSystem = FindAnyObjectByType<ScoreSystem>();
    }
    private void Update()
    {
        if(MyHealth <= 0)
        {
            Destroy(this.gameObject);
            scoreSystem.currentPoints += 100;
            Debug.Log("score went up");
        }
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("EnemyTakesDamage");
        MyHealth -= damage;
    }
}
