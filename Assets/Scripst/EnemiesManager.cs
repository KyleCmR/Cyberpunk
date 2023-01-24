using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemiesManager : MonoBehaviour
{
    [SerializeField] StageProgress stageProgress;
    [SerializeField] GameObject enemy;
    [SerializeField] Vector2 spawnArea;
    [SerializeField] float spawnTimer;
    GameObject player;
    [SerializeField] Slider bossHealthBar;

    List<Enemy> bossEnemiesList;
    int totalBossHeath;
    int currentBossHealth;

    private void Start()
    {
        player = GameManager.instance.playerTransform.gameObject;
        bossHealthBar = FindObjectOfType<BossHpBar>(true).GetComponent<Slider>();
    }

    private void Update()
    {
        UpdateBossHealth();
    }
    private void UpdateBossHealth()
    {
        if (bossEnemiesList == null) { return; }
        if (bossEnemiesList.Count == 0) { return; }

        currentBossHealth = 0;

        for (int i = 0; i < bossEnemiesList.Count; i++)
        {
            if (bossEnemiesList[i] == null) { continue; }
            currentBossHealth += bossEnemiesList[i].stats.hp;
        }
        bossHealthBar.value = currentBossHealth;

        if (currentBossHealth < 0)
        {
            bossHealthBar.gameObject.SetActive(false);
            bossEnemiesList.Clear();
        }
    }

    public void SpawnEnemy(EnemyData enemyToSpawn, bool isBoss)
    {
        Vector3 position = UtilityTools.GenerateRandomPositionSquarePattern(spawnArea);

        position += player.transform.position;

        // spawning main enemy object
        GameObject newEnemy = Instantiate(enemy); 
        newEnemy.transform.position = position;
        Enemy newEnemyComponent = newEnemy.GetComponent<Enemy>();
        newEnemyComponent.SetTarget(player);
        newEnemyComponent.SetStats(enemyToSpawn.stats);
        newEnemyComponent.UpdatesStatsForProgress(stageProgress.Progress);

        if (isBoss == true)
        {
            SpawnBossEnemy(newEnemyComponent);
        }

        newEnemy.transform.parent = transform;

        // spawning sprite object of th enemy
        GameObject spriteObject = Instantiate(enemyToSpawn.animatedPrefab);
        spriteObject.transform.parent = newEnemy.transform;
        spriteObject.transform.localPosition = Vector3.zero;
    }

    private void SpawnBossEnemy(Enemy newBoss)
    {
        if(bossEnemiesList == null) { bossEnemiesList = new List<Enemy>(); }

        bossEnemiesList.Add(newBoss);

        totalBossHeath += newBoss.stats.hp;

        bossHealthBar.gameObject.SetActive(true);
        bossHealthBar.maxValue= totalBossHeath;
    }
}
