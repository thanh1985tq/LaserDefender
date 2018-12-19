using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Configuration")]
public class WaveConfig : ScriptableObject
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] int enemyCount = 3;
    [SerializeField] bool isSyncApear = false;
    [SerializeField] float spawnTime = 2f;
    [SerializeField] GameObject enemyPath;
    [SerializeField] float moveSpeed = 3f;
    [SerializeField] int hp = 100;
    [SerializeField] float minFireRate = 2f;
    [SerializeField] float maxFireRate = 5f;

    public GameObject GetEnemy()
    {
        return enemyPrefab;
    }

    public int GetEnemyCount()
    {
        return enemyCount;
    }

    public bool IsSyncApear()
    {
        return isSyncApear;
    }

    public float GetSpawnTime()
    {
        return spawnTime;
    }

    public List<Transform> GetWayPoint()
    {
        List<Transform> wayPoint = new List<Transform>();

        foreach(Transform child in enemyPath.transform)
        {
            wayPoint.Add(child);
        }

        return wayPoint;
    }

    public float GetMoveSpeed()
    {
        return moveSpeed;
    }

    public int GetHP()
    {
        return hp;
    }

    public float GetFireRate()
    {
        return Random.Range(minFireRate, maxFireRate);
    }
}
