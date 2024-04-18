using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] List<WaveConfigOS> waveConfigs;
    [SerializeField] float timeBetweenSpawnWave = 0f;
    [SerializeField] bool isLooping;
    WaveConfigOS currentWave;

    void Start()
    {
        StartCoroutine(EnemiesSpawn());
    }
    public WaveConfigOS GetCurrentWave()
    {
        return currentWave;
    }

    IEnumerator EnemiesSpawn()
    {
        do
        {
            foreach(WaveConfigOS waveConfig in waveConfigs)
            {
                currentWave = waveConfig;
                for(int i = 0; i < currentWave.GetEnemyCount(); i++)
                {
                    Instantiate(currentWave.GetEnemyPrefab(i),
                                currentWave.GetStartingWaypoint().position,
                                Quaternion.Euler(0,0,180),
                                transform);
                    yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
                }
                yield return new WaitForSeconds(timeBetweenSpawnWave);
            }
        }
        while (isLooping);
    }
}
