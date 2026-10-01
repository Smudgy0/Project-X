using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    public Transform shootingPoint;
    public GameObject bulletPrefab;

    public void OnShoot(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            GameObject bulletClone = Instantiate(bulletPrefab, shootingPoint.position, transform.rotation);
            Destroy(bulletClone, 1f);
        }
    }
}
