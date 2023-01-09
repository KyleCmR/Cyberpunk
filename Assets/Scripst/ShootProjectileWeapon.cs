using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShootProjectileWeapon : MonoBehaviour
{
    [SerializeField] float timeToAttack;
    float timer;
    PlayerMove playerMove;
    [SerializeField] GameObject ShootProjectilePrefab;

    private void Awake()
    {
        playerMove = GetComponentInParent<PlayerMove>();
    }

    private void Update()
    {
        if (timer < timeToAttack)
        {
            timer += Time.deltaTime;
            return;
        }
        timer = 0;
        SpawnShootProjectile();

    }
    private void SpawnShootProjectile()
    {
        GameObject ShootProjectile = Instantiate(ShootProjectilePrefab);
        ShootProjectile.transform.position = transform.position;
        ShootProjectile.GetComponent<ShootProjectile>().SetDirection(playerMove.lastHorizontalVector, 0f);
    }
}
