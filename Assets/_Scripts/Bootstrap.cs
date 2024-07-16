using UnityEngine;

public class Bootstrap
{
    private static string LevelConfigPath = "Configs/Level";
    private static LevelConfig levelConfig;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Initialize()
    {
        levelConfig = Resources.Load<LevelConfig>(LevelConfigPath);

        ServiseLocator serviseLocator = new ServiseLocator();
        serviseLocator.AddService<LevelConfig>(levelConfig);

        LevelData level = GetNewLevel();
        serviseLocator.AddService<LevelData>(level);

        PauseSystem pause = new();
        serviseLocator.AddService<PauseSystem>(pause);

        GameRules gameRules = new(level, pause);
        serviseLocator.AddService<GameRules>(gameRules);
    }

    public static LevelData GetNewLevel()
    {
        int randomEnemyCount = GetEnemyCount();

        LevelData level = new(playerHealth: levelConfig.PlayerHealth, randomEnemyCount, levelConfig.SpawnSpeed);

        return level;
    }

    private static int GetEnemyCount()
    {
        return Random.Range(levelConfig.Count.x, levelConfig.Count.y + 1);//maxInclusive
    }

    public static void Restart()
    {
        LevelData level = ServiseLocator.instance.GetService<LevelData>();
        level.EnemyCount.Value = GetEnemyCount();
        level.PlayerHealth.Value = levelConfig.PlayerHealth;

        ServiseLocator.instance.GetService<GameRules>().IsGameEnd = false;
    }
}