using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class ShootProjectileWeapon : WeaponBase
{
    PlayerMove playerMove;
    [SerializeField] GameObject ShootProjectilePrefab;
    [SerializeField] float spred = 0.5f;


    private void Awake()
    {
        playerMove = GetComponentInParent<PlayerMove>();
    }

    public override void Attack()
    {

        for(int i = 0; i < weaponStats.numberOfAttacks; i++)
        {
            GameObject ShootProjectile = Instantiate(ShootProjectilePrefab);

            Vector3 newShootProjectilePosition = transform.position;
            if (weaponStats.numberOfAttacks > 0)
            {
                newShootProjectilePosition.y -= (spred * (weaponStats.numberOfAttacks - 1)) / 2;
                newShootProjectilePosition.y += i * spred;
            }

            ShootProjectile.transform.position = newShootProjectilePosition;

            ShootProjectile shootProjectile = ShootProjectile.GetComponent<ShootProjectile>();
            shootProjectile.SetDirection(playerMove.lastHorizontalVector, 0f);
            shootProjectile.damage = weaponStats.damage;
        }

    }
}
