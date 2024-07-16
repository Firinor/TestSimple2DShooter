using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Enemy : MonoBehaviour, ICanPause
{
    public Action<Enemy> OnEnd;
    public EnemyStats stats;

    private string bulletTag = "Bullet";
    private string targetTag = "ZombieTarget";

    private LevelData level;

    private void Awake()
    {
        level = ServiseLocator.instance.GetService<LevelData>();
        ((ICanPause)this).SubscribeToPause();
    }

    private void OnEnable()
    {
        GetRandomSkin();
    }

    private void GetRandomSkin()
    {
        Animator animator = GetComponent<Animator>();
        int random = UnityEngine.Random.Range(0, 4);
        animator.Play("WalkDown" + random);
    }

    private void Update()
    {
        transform.position += Vector3.down * stats.Speed * Time.deltaTime;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == bulletTag)
        {
            ref int health = ref stats.Health;
            Bullet bullet = other.GetComponent<Bullet>();
            health -= bullet.Damage;
            bullet.OnEnd?.Invoke(bullet);
            if (health <= 0)
            {
                level.EnemyCount.Value--;
                OnEnd?.Invoke(this);
            }
            return;
        }

        if (other.tag == targetTag)
        {
            level.PlayerHealth.Value--;
            level.EnemyCount.Value--;

            OnEnd?.Invoke(this);
        }
    }

    public void Pause()
    {
        GetComponent<Animator>().enabled = false;
        enabled = false;
    }

    private void OnDestroy()
    {
        ((ICanPause)this).Unsubscribe();
    }
}
