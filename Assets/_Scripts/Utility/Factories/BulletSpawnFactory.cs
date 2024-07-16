using UnityEngine;

public class BulletSpawnFactory : SpawnFactory<Bullet, BulletsStatsConfig>
{
    private int BulletDamage;
    private float BulletDistance;

    public BulletSpawnFactory(Bullet prefab, Transform parent, BulletsStatsConfig stats, PlayerStatsConfig player, Transform spawnPoint)
        : base(prefab, parent, stats, new Transform[1] { spawnPoint })
    {
        BulletDamage = player.Attack;
        BulletDistance = player.AttackRadius;
    }

    public override void AddNewObject()
    {
        Bullet bullet;

        if (freeObjects.Count == 0)
        {
            bullet = AddNewInstance();
            bullet.OnEnd += ToReserve;
            bullet.Speed = stats.Speed;
            bullet.Distance = BulletDistance;
            bullet.Damage = BulletDamage;
        }
        else
            bullet = freeObjects[0];

        Transform spawnPoint = spawnPoints[0];

        bullet.transform.position = spawnPoint.position;
        bullet.gameObject.SetActive(true);
    }
}