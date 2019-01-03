using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Configuration")]
public class WaveConfig : ScriptableObject
{
    [Header("Enemy Config")]
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] int hp = 100;
    [SerializeField] float minFireRate = 2f;
    [SerializeField] float maxFireRate = 5f;
    [SerializeField] GameObject enemyPath;
    [SerializeField] float moveSpeed = 3f;

    [Header("Wave Config")]
    [Tooltip("0 = move follow waypoint, 1 = random between one point, 2 = spread from multiple point")]
    [SerializeField] int apearType = 0; //0 = move follow waypoint, 1 = random between 1 point, 2 = spread from multiple point
    [SerializeField] int enemyCount = 3;
    [SerializeField] float spawnTime = 2f;

    public GameObject GetEnemy()
    {
        return enemyPrefab;
    }

    public int GetEnemyCount()
    {
        return enemyCount;
    }

    public int GetApearType(){
        return apearType;
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

    public float GetMinFireRate()
    {
        return minFireRate;
    }

    public float GetMaxFireRate()
    {
        return maxFireRate;
    }

    public float GetFireRate()
    {
        return Random.Range(minFireRate, maxFireRate);
    }
}
