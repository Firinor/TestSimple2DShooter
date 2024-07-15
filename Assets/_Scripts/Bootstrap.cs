using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    private static string LevelConfigPath = "Configs/Level";

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Initialize()
    {
        LevelConfig levelConfig = Resources.Load<LevelConfig>(LevelConfigPath);

        ServiseLocator serviseLocator = new ServiseLocator();
        serviseLocator.AddService<LevelConfig>(levelConfig);

        LevelData level = GetNewLevel(levelConfig);
        serviseLocator.AddService<LevelData>(level);
    }

    private static LevelData GetNewLevel(LevelConfig levelConfig)
    {
        LevelData level = new();

        level.PlayerHealth = 5;
        level.EnemyCount = Random.Range(levelConfig.Count.x, levelConfig.Count.y + 1);//maxInclusive
        level.SpawnSpeed = levelConfig.SpawnSpeed;

        return level;
    }
}
