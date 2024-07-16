using UnityEngine;

public class LevelData
{
    public ReactiveValue<int> PlayerHealth;
    public ReactiveValue<int> EnemyCount;
    public Vector2 SpawnSpeed;

    public LevelData(int playerHealth, int enemyCount, Vector2 spawnSpeed)
    {
        PlayerHealth = new(playerHealth);
        EnemyCount = new(enemyCount);
        SpawnSpeed = spawnSpeed;
    }
}
