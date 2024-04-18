using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Config", fileName = "New Wave Config")]
public class WaveConfigOS : ScriptableObject
{
    [SerializeField] List<GameObject> enemyPrefab;
    [SerializeField] Transform pathPrefab;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float timeBetweenSpawns = 0.5f;
    [SerializeField] float spawnTimeVariance = 0f;
    [SerializeField] float minimumSpawnTime = 0.2f;
    public Transform GetStartingWaypoint()
    {
        return pathPrefab.GetChild(0);
    }
    public List<Transform> GetWaypoints()
    {
        List<Transform> waypoints = new List<Transform>();
        foreach(Transform waypoint in pathPrefab)
        {
            waypoints.Add(waypoint);
        }
        return waypoints;
    }
    public float GetMoveSpeed()
    {
        return moveSpeed;
    }
    public int GetEnemyCount()
    {
        return enemyPrefab.Count;
    }
    public GameObject GetEnemyPrefab(int index)
    {
        return enemyPrefab[index];
    }
    public  float GetRandomSpawnTime()
    {
        float spawnTime = UnityEngine.Random.Range(timeBetweenSpawns - spawnTimeVariance,
                                                    timeBetweenSpawns + spawnTimeVariance);
        return Mathf.Clamp(spawnTime, minimumSpawnTime, float.MaxValue);
    }
}
