using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunWeapon : WeaponBase
{
    [SerializeField] GameObject bulletPrefab;

    public override void Attack()
    {
        UpdateVectorOfAttack();
        for (int i = 0; i < weaponStats.numberOfAttacks; i++)
        {
            GameObject ShootProjectile = Instantiate(bulletPrefab);

            Vector3 newShootProjectilePosition = transform.position;

            ShootProjectile.transform.position = newShootProjectilePosition;

            ShootProjectile shootProjectile = ShootProjectile.GetComponent<ShootProjectile>();
            shootProjectile.SetDirection(vectorOfAttack.x, vectorOfAttack.y);
            shootProjectile.damage = GetDamage();
        }
    }
}
