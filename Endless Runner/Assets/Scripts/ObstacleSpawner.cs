using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    private int spawnInterval = 30;
    private int initialObstaces = 4;
    private int lastSpawnZ = 70;
    private int initSpawn = 160;
    private int spawnAmount = 20;
    public List<GameObject> obstacles;
    private HashSet<Vector3> spawnedPositions = new HashSet<Vector3>();

    void Start()
    {
        InitializeObstacles();
    }

    void Update()
    {
        
    }

    public void InitializeObstacles()
    {
        for (int i = 0; i < initialObstaces; i++)
        {
            Vector3 spawnPosition = new Vector3(0, -0.01f, lastSpawnZ + i * spawnInterval);
            GameObject obstacle = obstacles[UnityEngine.Random.Range(0, obstacles.Count)];
            Instantiate(obstacle, spawnPosition, obstacle.transform.rotation);
            spawnedPositions.Add(spawnPosition);
        }
    }

    public void SpawnObstacles()
    {
        initSpawn += spawnInterval;

        for (int i = 0; i < spawnAmount; i++)
        {
            if (UnityEngine.Random.Range(0, 4) == 0)
            {
                Vector3 spawnPosition = new Vector3(0, -0.01f, initSpawn);

                if (!spawnedPositions.Contains(spawnPosition)) // Check if position is already occupied
                {
                    GameObject obstacle = obstacles[UnityEngine.Random.Range(0, obstacles.Count)];
                    Instantiate(obstacle, spawnPosition, obstacle.transform.rotation);
                    spawnedPositions.Add(spawnPosition); // Add position to the set of spawned positions
                }
            }
        }
    }
}
