using UnityEngine;
using UnityEngine.InputSystem;

public class AttackChecker : MonoBehaviour
{
    

    public int playerDamage;

    public PlayerMovement PM;

    public Transform meleePoint;
    public LayerMask acceptedTargets;
    public Transform shootingPoint;
    public GameObject bulletPrefab;

    private void Awake()
    {
        playerDamage = 1;
        PM = FindAnyObjectByType<PlayerMovement>();
    }

    public void Update()
    {
        if(PM.facingDirection.x < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            switch(PM.ActiveCharater.AttackForm)
            {
                case CharacterInfo.AttackType.Melee:
                    Collider2D hit = Physics2D.OverlapCircle(meleePoint.position, 0.5f, acceptedTargets);
                    if(hit != null)
                    {
                        if(hit.TryGetComponent(out EnemyHealth enemyHealth))
                        {
                            enemyHealth.TakeDamage(playerDamage);
                        }
                    }

                    break;
                case CharacterInfo.AttackType.Ranged:
                    GameObject bulletClone = Instantiate(bulletPrefab, shootingPoint.position, transform.rotation);
                    Destroy(bulletClone, 1f);
                    break;
            }
        }
    }

}
