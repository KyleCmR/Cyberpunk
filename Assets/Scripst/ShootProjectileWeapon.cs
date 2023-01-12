using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShootProjectileWeapon : WeaponBase
{
    PlayerMove playerMove;
    [SerializeField] GameObject ShootProjectilePrefab;

    private void Awake()
    {
        playerMove = GetComponentInParent<PlayerMove>();
    }

    public override void Attack()
    {
        GameObject ShootProjectile = Instantiate(ShootProjectilePrefab);
        ShootProjectile.transform.position = transform.position;
        ShootProjectile.GetComponent<ShootProjectile>().SetDirection(playerMove.lastHorizontalVector, 0f);
    }
}
