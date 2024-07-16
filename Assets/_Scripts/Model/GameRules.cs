using UnityEngine;

public class GameRules
{
    private PauseSystem pauseSystem;
    public RectTransform parent;

    private static string WinPath = "WinLosePopups/WinPopup";
    private static string LosePath = "WinLosePopups/LosePopup";

    public bool IsGameEnd = false;

    public GameRules(LevelData level, PauseSystem pauseSystem)
    {
        level.PlayerHealth.OnValueChange += OnHealthChanged;
        level.EnemyCount.OnValueChange += OnEnemyCountChanged;
        this.pauseSystem = pauseSystem;
    }

    private void OnEnemyCountChanged(int enemiesCount)
    {
        if (IsGameEnd)
            return;

        if (enemiesCount <= 0)
            Win();
    }

    private void Win()
    {
        EndCurrentGame();
        var winPrefab = Resources.Load<GameObject>(WinPath);
        GameObject.Instantiate(winPrefab, parent);
    }

    private void EndCurrentGame()
    {
        IsGameEnd = true;
        pauseSystem.GameToPause();
    }

    private void OnHealthChanged(int healthCount)
    {
        if (IsGameEnd)
            return;

        if (healthCount <= 0)
            Lose();
    }

    private void Lose()
    {
        EndCurrentGame();
        var losePrefab = Resources.Load<GameObject>(LosePath);
        GameObject.Instantiate(losePrefab, parent);
    }
}
