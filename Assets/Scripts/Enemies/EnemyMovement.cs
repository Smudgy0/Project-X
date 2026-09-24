using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public int zombieMoveSpeed;
    public int zombieMoveDirection;

    public int minZombieFlipTimer;
    public int maxZombieFlipTimer;
    private int zombieFlipTimer;

    public GameObject myAttackBox;

    private Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        zombieMoveDirection = 1; // starts going to the right


        zombieFlipTimer = Random.Range(minZombieFlipTimer, maxZombieFlipTimer);
        InvokeRepeating("ChangeDirection", zombieFlipTimer, zombieFlipTimer);
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocityY = 0;
        rb.linearVelocityX = zombieMoveDirection * zombieMoveSpeed;
    }

    public void ChangeDirection()
    {
        zombieMoveDirection = -zombieMoveDirection;
        myAttackBox.gameObject.transform.localPosition = -myAttackBox.gameObject.transform.localPosition;
    }
}
