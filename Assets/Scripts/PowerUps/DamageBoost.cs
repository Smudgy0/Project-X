using System.Collections;
using UnityEngine;
using System;

public class DamageBoost : MonoBehaviour
{
    public Bullet bullet;
    public AttackChecker attackChecker;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            attackChecker.playerIncreasedDamage = attackChecker.playerDamage * 2;
            bullet.increasedBulletDamage = bullet.bulletDamage * 2;
            StartCoroutine(Delay());
            gameObject.SetActive(false);
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(5);
        attackChecker.playerIncreasedDamage = attackChecker.playerDamage;
        bullet.increasedBulletDamage = bullet.bulletDamage;
    }
}
