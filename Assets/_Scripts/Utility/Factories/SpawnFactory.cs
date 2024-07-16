using System.Collections.Generic;
using UnityEngine;

public class SpawnFactory<T, TStats> where T : MonoBehaviour
{
    protected T prefab;
    protected Transform parent;
    protected TStats stats;

    //private List<Enemy> allEnemies;
    protected List<T> freeObjects = new();

    protected List<Transform> spawnPoints;

    public SpawnFactory(
        T prefab,
        Transform parent,
        TStats stats,
        Transform[] spawnPoints)
    {
        this.prefab = prefab;
        this.parent = parent;
        this.stats = stats;
        this.spawnPoints = new(spawnPoints);
    }

    public virtual void AddNewObject()
    {
        T obj;

        if (freeObjects.Count == 0)
        {
            obj = AddNewInstance();
        }
        else
            obj = freeObjects[0];

        int index = Random.Range(0, spawnPoints.Count);
        Transform spawnPoint = spawnPoints[index];

        obj.transform.position = spawnPoint.position;
        obj.gameObject.SetActive(true);
    }

    protected T AddNewInstance()
    {
        return GameObject.Instantiate(prefab, parent);
    }

    public virtual void ToReserve(T obj)
    {
        freeObjects.Add(obj);
        obj.gameObject.SetActive(false);
    }
}