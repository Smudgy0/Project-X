using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public EnemyStats EnemyType;
    public int MyHealth;

    private void Awake()
    {
        MyHealth = EnemyType.health;
    }
    private void Update()
    {
        if(MyHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("EnemyTakesDamage");
        MyHealth -= damage;
    }
}
