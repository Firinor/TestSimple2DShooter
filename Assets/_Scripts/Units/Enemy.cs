using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Action<Enemy> OnDeath;
    public EnemyStats stats;

    private string bulletTag = "Bullet";
    private string targetTag = "ZombieTarget";

    private void Update()
    {
        transform.position += Vector3.down * stats.Speed * Time.deltaTime;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == bulletTag)
        {
            ref int health = ref stats.Health;
            health -= other.GetComponent<Bullet>().Damage;
            if(health <= 0)
                OnDeath?.Invoke(this);
            return;
        }

        if (other.tag == targetTag)
        {
            ServiseLocator.instance.GetService<LevelData>().PlayerHealth--;
            OnDeath?.Invoke(this);
        }
    }
}
