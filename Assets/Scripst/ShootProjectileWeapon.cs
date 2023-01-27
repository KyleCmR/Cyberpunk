using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class ShootProjectileWeapon : WeaponBase
{
    [SerializeField] GameObject ShootProjectilePrefab;
    [SerializeField] float spread = 0.5f;

    public override void Attack()
    {
        UpdateVectorOfAttack();
        for(int i = 0; i < weaponStats.numberOfAttacks; i++)
        {
            GameObject ShootProjectile = Instantiate(ShootProjectilePrefab);

            Vector3 newShootProjectilePosition = transform.position;
            if (weaponStats.numberOfAttacks > 0)
            {
                newShootProjectilePosition.y -= (spread * (weaponStats.numberOfAttacks - 1)) / 2;
                newShootProjectilePosition.y += i * spread;
            }

            ShootProjectile.transform.position = newShootProjectilePosition;

            ShootProjectile shootProjectile = ShootProjectile.GetComponent<ShootProjectile>();
            shootProjectile.SetDirection(vectorOfAttack.x, vectorOfAttack.y);
            shootProjectile.damage = GetDamage();
        }
    }
}
