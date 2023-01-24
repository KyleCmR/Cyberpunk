using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class EnemyStats
{
    public int hp = 4;
    public int damage = 1;
    public int experience_reward = 400;
    public float moveSpeed = 1f;

    public EnemyStats(EnemyStats stats)
    {
        this.hp = stats.hp;
        this.damage = stats.damage;
        this.experience_reward= stats.experience_reward;
        this.moveSpeed = stats.moveSpeed;
    }

    internal void ApplyProgress(float progress)
    {
        this.hp = (int)(hp * progress);
        this.damage = (int)(damage * progress);
    }
}


public class Enemy : MonoBehaviour, IDamagleble
{
    Transform targetDestination; 
    GameObject targetGameobject;
    Character targetCharacter;

    Rigidbody2D rgdbd2d;

    public EnemyStats stats;

    private void Awake()
    {
        rgdbd2d = GetComponent<Rigidbody2D>();
    }
    public void SetTarget(GameObject target)
    {
        targetGameobject = target;
        targetDestination = target.transform;
    }

    private void FixedUpdate()
    {
        Vector3 direction = (targetDestination.position - transform.position).normalized;
        rgdbd2d.velocity = direction * stats.moveSpeed;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject == targetGameobject)
        {
            Attack();
        }
    }

    private void Attack()
    {
        if (targetCharacter == null)
        {
            targetCharacter = targetGameobject.GetComponent<Character>();
        }

        targetCharacter.TakeDamage(stats.damage);
    }

    public void TakeDamage(int damage)
    {
        stats.hp -= damage;

        if (stats.hp < 1)
        {
            targetGameobject.GetComponent<Level>().AddExperience(stats.experience_reward);
            GetComponent<DropOnDestoy>().CheckDrop();
            Destroy(gameObject);
        }
    }

    internal void SetStats(EnemyStats stats)
    {
        this.stats = new EnemyStats(stats);
    }

    internal void UpdatesStatsForProgress(float progress)
    {
        stats.ApplyProgress(progress);
    }
}
