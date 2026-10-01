using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyMovement : MonoBehaviour
{
    public int zombieMoveSpeed;
    public int zombieMoveDirection;

    private int zombieFlipTimer;

    public GameObject myAttackBox;

    // HP
    public int MyHealth;

    public int chosenEnemy;
    public EnemyStats[] AviableEnemys;
    private EnemyStats EnemyType;

    //Spirte
    public SpriteRenderer SR;

    // GroundChecker
    public float groundCheckRadius;
    public LayerMask groundMask;
    public Collider2D isGroundedLeft;
    public Collider2D isGroundedRight;

    public Transform groundCheckObjectLeft;
    public Transform groundCheckObjectRight;

    // Patrol CheckPoints
    public Transform[] WayPoints;
    public Transform TargetWayPoint;
    public int CurrentWayPoint;

    private Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        zombieMoveDirection = 1; // starts going to the right

        // chosen random enemy preset
        chosenEnemy = Random.Range(0, AviableEnemys.Length);
        EnemyType = AviableEnemys[chosenEnemy];

        // apply enemy stats
        zombieMoveSpeed = EnemyType.Speed;
        MyHealth = EnemyType.health;
        SR.color = EnemyType.MyColor;

        // Patrol
        CurrentWayPoint = 0;
        TargetWayPoint = WayPoints[CurrentWayPoint];
        this.transform.position = TargetWayPoint.position;
    }

    // Update is called once per frame
    void Update()
    {
        isGroundedLeft = Physics2D.OverlapCircle(groundCheckObjectLeft.position, groundCheckRadius, groundMask);
        isGroundedRight = Physics2D.OverlapCircle(groundCheckObjectRight.position, groundCheckRadius, groundMask);

        if (!isGroundedLeft)
        {
            zombieMoveDirection = 1;
        }
        else if (!isGroundedRight)
        {
            zombieMoveDirection = -1;
        }

        rb.linearVelocityY = 0;
        rb.linearVelocityX = zombieMoveDirection * zombieMoveSpeed;

        if (MyHealth <= 0)
        {
            Destroy(this.gameObject);
        }

        if (this.transform.position.x == TargetWayPoint.transform.position.x)
        {
            Flip();
            if (CurrentWayPoint == WayPoints.Length)
            {
                CurrentWayPoint = 0;
            }
            else
            {
                CurrentWayPoint++;
            }

            CurrentWayPoint = Math.Clamp(CurrentWayPoint, 0, 1);
        }
    }

    public void Flip()
    {
        zombieMoveDirection = -zombieMoveDirection;
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("EnemyTakesDamage");
        MyHealth -= damage;
    }
}
