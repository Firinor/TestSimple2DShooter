using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "GameConfigs/PlayerStats")]
public class PlayerStatsConfig : ScriptableObject
{
    public float Speed;
    public float AttackSpeed;
    public float AttackRadius;
    public int Attack;
}
