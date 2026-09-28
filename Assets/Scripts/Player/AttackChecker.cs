using UnityEngine;
using UnityEngine.InputSystem;

public class AttackChecker : MonoBehaviour
{
    public LayerMask AcceptedTargets;
    public EnemyHealth EnemyTarget;
    public GameObject MyAttackPointChecker;

    public int playerDamage;

    public PlayerMovement PM;

    private void Awake()
    {
        playerDamage = 1;
        PM = FindAnyObjectByType<PlayerMovement>();
    }

    private void Update()
    {
        if(PM.rb.linearVelocityX > 0)
        {
            MyAttackPointChecker.transform.localPosition = new Vector2(1,0);
        }
        else
        {
            MyAttackPointChecker.transform.localPosition = new Vector2(-1, 0);
        }
    }

    public void OnAttack(InputAction.CallbackContext value)
    {
        if(EnemyTarget == null) { return; }
        if (value.performed)
        {
            EnemyTarget.TakeDamage(playerDamage);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            EnemyTarget = collision.GetComponent<EnemyHealth>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            EnemyTarget = null;
        }
    }
}
