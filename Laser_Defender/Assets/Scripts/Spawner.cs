using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfig;
    [SerializeField] float waveDelay = 20f;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        //DEBUG
        //WaveConfig wave1 = waveConfig[0];

        for (int i = 0; i < waveConfig.Count; i++)
        {
            StartCoroutine(SpawnAllEnemiesInWave(waveConfig[i]));
            yield return new WaitForSeconds(waveDelay);
        }
    }

    private IEnumerator SpawnAllEnemiesInWave(WaveConfig wc)
    {
        GameObject enemyPrefab = wc.GetEnemy();

        enemyPrefab.GetComponent<Enemy>()
            .SetEnemyParams(wc.GetHP(), wc.GetMinFireRate(), wc.GetMaxFireRate(), wc.GetWayPoint(), wc.GetMoveSpeed());
        for (int i = 0; i < wc.GetEnemyCount(); i++)
        {
            GameObject enemy = Instantiate(enemyPrefab, enemyPrefab.transform.position, Quaternion.identity);

            yield return new WaitForSeconds(wc.GetSpawnTime());
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
