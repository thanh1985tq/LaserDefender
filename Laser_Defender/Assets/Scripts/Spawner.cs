using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfig;

    // Start is called before the first frame update
    void Start()
    {
        //DEBUG
        WaveConfig wave1 = waveConfig[0];
        

        StartCoroutine(SpawnAllEnemiesInWave(wave1));
    }

    private IEnumerator SpawnAllEnemiesInWave(WaveConfig wave1)
    {
        GameObject enemyPrefab = wave1.GetEnemy();
        enemyPrefab.GetComponent<Enemy>().SetWayPoint(wave1.GetWayPoint());
        for (int i = 0; i < wave1.GetEnemyCount(); i++)
        {
            GameObject enemy = Instantiate(enemyPrefab, enemyPrefab.transform.position, Quaternion.identity);
            //enemy.GetComponent<Enemy>().SetWayPoint(wave1.GetWayPoint());

            yield return new WaitForSeconds(wave1.GetSpawnTime());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
