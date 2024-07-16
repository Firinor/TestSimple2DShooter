using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "GameConfigs/Level")]
public class LevelConfig : ScriptableObject
{
    [MinMaxRange(0, 10, 3)]
    public Vector2 SpawnSpeed = new(2, 4);
    [MinMaxRange(1, 30)]
    public Vector2Int Count = new(10, 15);
    [Min(1)]
    public int PlayerHealth = 5;
}