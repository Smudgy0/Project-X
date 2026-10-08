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
        // if dead, die.

        if (MyHealth <= 0)
        {
            Destroy(this.gameObject);
        }

        // if the enemy reaches the edge of a platform, change enemies direction and patrol point (failsafe).

        if (!isGroundedLeft)
        {
            TargetWayPoint = WayPoints[1];
            Flip(1);
        }
        else if (!isGroundedRight)
        {
            TargetWayPoint = WayPoints[0];
            Flip(-1);
        }

        // once the enemy has reach the X value of the patrol point transport, flip the movement direction of the enemy and set its waypoint to the 2nd waypoint.

        if (this.transform.position.x < TargetWayPoint.transform.position.x && zombieMoveDirection != 1) // first patrol point MUST be the lowest X value
        {
            TargetWayPoint = WayPoints[1];
            Flip(1);
        }
        else if(this.transform.position.x > TargetWayPoint.transform.position.x && zombieMoveDirection != -1) // second patrol point MUST be the highest X value
        {
            TargetWayPoint = WayPoints[0];
            Flip(-1);
        }

        // flip the attack box to be on the side the enemy is moving

        if(rb.linearVelocityX > 0 && myAttackBox.transform.localPosition.x < 0)
        {
            FlipAttackBox();
        }
        else if(rb.linearVelocityX < 0 && myAttackBox.transform.localPosition.x > 0)
        {
            FlipAttackBox();
        }
    }

    private void FixedUpdate()
    {
        // ground checks and movement.

        isGroundedLeft = Physics2D.OverlapCircle(groundCheckObjectLeft.position, groundCheckRadius, groundMask);
        isGroundedRight = Physics2D.OverlapCircle(groundCheckObjectRight.position, groundCheckRadius, groundMask);

        rb.linearVelocityY = 0;
        rb.linearVelocityX = zombieMoveDirection * zombieMoveSpeed;
    }

    public void Flip(int moveDirection)
    {
        zombieMoveDirection = moveDirection;
    }

    public void FlipAttackBox()
    {
        myAttackBox.transform.localPosition = -myAttackBox.transform.localPosition;
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("EnemyTakesDamage");
        MyHealth -= damage;
    }
}
