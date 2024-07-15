using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnFactory
{
    private Enemy enemyPrefab;
    private Transform enemyParent;
    private EnemyStatsConfig enemyStats;

    //private List<Enemy> allEnemies;
    private List<Enemy> freeEnemy = new();

    private List<Transform> spawnPoints;

    public EnemySpawnFactory(
        Enemy enemyPrefab,
        Transform enemyParent,
        EnemyStatsConfig enemyStats,
        Transform[] spawnPoints)
    {
        this.enemyPrefab = enemyPrefab;
        this.enemyParent = enemyParent;
        this.enemyStats = enemyStats;
        this.spawnPoints = new(spawnPoints);
    }

    public void AddEnemy()
    {
        Enemy enemy;

        if (freeEnemy.Count == 0)
        {
            enemy = AddNewInstance();
            enemy.OnDeath += RemoveEnemy;
        }
        else
            enemy = freeEnemy[0];

        int index = Random.Range(0, spawnPoints.Count);
        Transform spawnPoint = spawnPoints[index];

        enemy.transform.position = spawnPoint.position;
        enemy.stats = GetRandomStats();
        enemy.gameObject.SetActive(true);
    }

    private EnemyStats GetRandomStats()
    {
        float randomSpeed = Random.Range(enemyStats.Speed.x, enemyStats.Speed.y);

        return new(randomSpeed, enemyStats.Health);
    }

    private Enemy AddNewInstance()
    {
        return GameObject.Instantiate(enemyPrefab, enemyParent);
    }

    public void RemoveEnemy(Enemy enemy)
    {
        freeEnemy.Add(enemy);
        enemy.gameObject.SetActive(false);
    }
}
