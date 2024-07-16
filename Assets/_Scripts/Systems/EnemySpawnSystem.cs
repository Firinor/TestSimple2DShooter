using UnityEngine;

public class EnemySpawnSystem : MonoBehaviour, ICanPause
{
    [SerializeField] private EnemyStatsConfig enemyStats;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private Enemy enemyPrefab;
    [SerializeField] private Transform enemyParent;

    private EnemySpawnFactory factory;

    private Vector2 spawnSpeed;

    private float currentCooldown;
    private int enemyCounter;

    private void Awake()
    {
        factory = new(enemyPrefab, enemyParent, enemyStats, spawnPoints);
        LevelData levelData = ServiseLocator.instance.GetService<LevelData>();
        spawnSpeed = levelData.SpawnSpeed;
        enemyCounter = levelData.EnemyCount.Value;

        ((ICanPause)this).SubscribeToPause();
    }

    private void Update()
    {
        currentCooldown -= Time.deltaTime;

        if (currentCooldown > 0)
            return;

        factory.AddNewObject();

        enemyCounter--;
        if (enemyCounter <= 0)
        {
            gameObject.SetActive(false);
            return;
        }

        currentCooldown += GetCooldown();
    }

    private float GetCooldown()
    {
        return Random.Range(spawnSpeed.x, spawnSpeed.y);
    }

    public void Pause()
    {
        enabled = false;
    }

    private void OnDestroy()
    {
        ((ICanPause)this).Unsubscribe();
    }
}
