using UnityEngine;

public class EnemySpawnFactory : SpawnFactory<Enemy, EnemyStatsConfig>
{
    public EnemySpawnFactory(Enemy prefab, Transform parent, EnemyStatsConfig stats, Transform[] spawnPoints)
        : base(prefab, parent, stats, spawnPoints)
    {

    }

    public override void AddNewObject()
    {
        Enemy enemy;

        if (freeObjects.Count == 0)
        {
            enemy = AddNewInstance();
            enemy.OnEnd += ToReserve;
        }
        else
            enemy = freeObjects[0];

        int index = Random.Range(0, spawnPoints.Count);
        Transform spawnPoint = spawnPoints[index];

        enemy.transform.position = spawnPoint.position;
        enemy.stats = GetRandomStats();
        enemy.gameObject.SetActive(true);
    }

    private EnemyStats GetRandomStats()
    {
        float randomSpeed = Random.Range(stats.Speed.x, stats.Speed.y);

        return new(randomSpeed, stats.Health);
    }
}
