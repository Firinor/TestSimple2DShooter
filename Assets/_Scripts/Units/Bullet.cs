using System;
using UnityEngine;

public class Bullet : MonoBehaviour, ICanPause
{
    internal Action<Bullet> OnEnd;

    public int Damage;
    public float Speed;
    public float Distance = 15;
    
    private float lifeTime = 15;
    private float lifeTimeLeft;

    private float lifeDistanceLeft;

    private void Awake()
    {
        ((ICanPause)this).SubscribeToPause();
    }

    private void OnEnable()
    {
        lifeTimeLeft = lifeTime;
        lifeDistanceLeft = Distance;
    }

    private void Update()
    {
        Vector3 deltaPosition = Vector3.up * Speed * Time.deltaTime;
        transform.position += deltaPosition;

        lifeDistanceLeft -= deltaPosition.magnitude;
        if(lifeDistanceLeft <= 0)
        {
            OnEnd?.Invoke(this);
            return;
        }

        lifeTimeLeft -= Time.deltaTime;
        if (lifeTimeLeft <= 0)
            OnEnd?.Invoke(this);
    }

    public void Pause()
    {
        GetComponent<Animator>().enabled = false;
        enabled = true;
    }
    private void OnDestroy()
    {
        ((ICanPause)this).Unsubscribe();
    }
}
