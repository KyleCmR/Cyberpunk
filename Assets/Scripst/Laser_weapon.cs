using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser_weapon : WeaponBase
{
    [SerializeField] GameObject leftLaserObject;
    [SerializeField] GameObject rightLaserObject;

    PlayerMove playerMove;
    [SerializeField] Vector2 attackSize = new Vector2(4f, 2f);

    private void Awake()
    {
        playerMove = GetComponentInParent<PlayerMove>();
    }

    public override void Attack()
    {
        StartCoroutine(AttackProcess());
    }

    IEnumerator AttackProcess()
    {
        for (int i = 0; i < weaponStats.numberOfAttacks; i++)
        {
            if (playerMove.lastHorizontalDeCoupledVector > 0)
            {
                rightLaserObject.SetActive(true);
                Collider2D[] colliders = Physics2D.OverlapBoxAll(rightLaserObject.transform.position, attackSize, 0f);
                ApplyDamage(colliders);
            }
            else
            {
                leftLaserObject.SetActive(true);
                Collider2D[] colliders = Physics2D.OverlapBoxAll(leftLaserObject.transform.position, attackSize, 0f);
                ApplyDamage(colliders);
            }
        }
        yield return new WaitForSeconds(0.3f);
    }
}
