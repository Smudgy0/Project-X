using System.Collections;
using UnityEngine;
using System;

public class MovementSpeedBoost : MonoBehaviour
{
    public PlayerManager playerManager;

    private void onTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            playerManager.playerRunSpeed = playerManager.PlayerMoveSpeed * 2;
            StartCoroutine(Delay());
            gameObject.SetActive(false);
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(5);
        playerManager.playerRunSpeed = playerManager.PlayerMoveSpeed;
    }
}
