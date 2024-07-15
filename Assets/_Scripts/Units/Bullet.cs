using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int Damage;
    public int Speed;

    void Update()
    {
        transform.position += Vector3.up * Speed * Time.deltaTime;
    }
}
