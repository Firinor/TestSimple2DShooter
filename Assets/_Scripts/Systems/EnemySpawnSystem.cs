using UnityEngine;

public class EnemySpawnSystem : MonoBehaviour
{
    [SerializeField] private EnemyStatsConfig enemyStats;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private Enemy enemyPrefab;
    [SerializeField] private Transform enemyParent;

    private EnemySpawnFactory factory;
    private LevelData levelData;

    private float currentCooldown;
    private int enemyCounter;

    private void Awake()
    {
        factory = new(enemyPrefab, enemyParent, enemyStats, spawnPoints);
        levelData = ServiseLocator.instance.GetService<LevelData>();
    }

    private void Update()
    {
        currentCooldown -= Time.deltaTime;

        if (currentCooldown > 0)
            return;

        factory.AddEnemy();

        enemyCounter++;
        if (enemyCounter >= levelData.EnemyCount)
        {
            gameObject.SetActive(false);
            return;
        }

        currentCooldown += GetCooldown();
    }

    private float GetCooldown()
    {
        return Random.Range(levelData.SpawnSpeed.x, levelData.SpawnSpeed.y);
    }
}
