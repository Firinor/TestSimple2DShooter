using UnityEngine;

[CreateAssetMenu(fileName = "EnemyStats", menuName = "GameConfigs/EnemyStats")]
public class EnemyStatsConfig : ScriptableObject
{
    [MinMaxRange(0, 10, 3)]
    public Vector2 Speed = new(2, 4);
    public int Health;
}