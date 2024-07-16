using System;
using UnityEngine;

public class PlayerShootController : MonoBehaviour, ICanPause
{
    [SerializeField] private Transform spawnPoint;

    [SerializeField] private PlayerStatsConfig playerStats;
    [SerializeField] private BulletsStatsConfig bulletStats;

    [SerializeField] private LayerMask enemiesLayer;

    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private Transform bulletParent;

    private BulletSpawnFactory factory;

    private float currentCooldown;

    private Vector2 enemyPosition;

    private void Awake()
    {
        factory = new(bulletPrefab, bulletParent, bulletStats, playerStats, spawnPoint);
        ((ICanPause)this).SubscribeToPause();
    }

    private void Update()
    {
        if (currentCooldown > 0)
            currentCooldown -= Time.deltaTime;
        else if (EnemyAhead())
            Shoot();
    }

    private void Shoot()
    {
        LookAtEnemy();
        factory.AddNewObject();
        currentCooldown += playerStats.AttackCooldown;
    }

    private void LookAtEnemy()
    {
        if(!TryGetComponent<Animator>(out Animator animator))
            return;

        Vector2 direction = enemyPosition - (Vector2)transform.position;
        animator.SetFloat("horizontal", direction.x);
        animator.SetFloat("vertical", direction.y);
    }

    private bool EnemyAhead()
    {
        RaycastHit2D hit = Physics2D.Raycast(spawnPoint.position, Vector2.up, playerStats.AttackRadius, enemiesLayer);

#if UNITY_EDITOR && DEBUG
        Debug.DrawRay(spawnPoint.position, Vector2.up * playerStats.AttackRadius, Color.red);
#endif

        if (hit.collider == null)
            return false;

        enemyPosition = hit.transform.position;

        return true;
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
