using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class AttackChecker : MonoBehaviour
{
    

    public int playerDamage;

    public PlayerManager PM;

    public Transform meleePoint;
    public LayerMask acceptedTargets;
    public Transform shootingPoint;
    public GameObject bulletPrefab;
    public int currentAmmo;
    public int maxAmmo;
    public int minAmmo;
    public float reloadTime;
    private bool reloading;

    public PlayerSpirteAnimator PSA;

    private void Awake()
    {
        playerDamage = 1;
        PM = FindAnyObjectByType<PlayerManager>();
<<<<<<< Updated upstream
        PSA = FindAnyObjectByType<PlayerSpirteAnimator>();
=======
        currentAmmo = maxAmmo;
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
                    PSA.RunMeleeAnim(); // Melee Animation trigger

=======
                    // theo one line
>>>>>>> Stashed changes
                    break;
                case CharacterInfo.AttackType.Ranged:
                    if (currentAmmo > minAmmo)
                    {
                        GameObject bulletClone = Instantiate(bulletPrefab, shootingPoint.position, transform.rotation);
                        Destroy(bulletClone, 1f);
                        currentAmmo--;
                        if (currentAmmo <= minAmmo)
                        {
                            if (!reloading)
                            {
                                StartCoroutine("Reload");
                            }
                        }
                    }
                    break;
            }

        }
    }

    IEnumerator Reload()
    {
        reloading = true;
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = maxAmmo;
        reloading = false;
    }
}
