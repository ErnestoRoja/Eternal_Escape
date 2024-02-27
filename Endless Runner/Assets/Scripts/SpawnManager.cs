using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    RoadSpawner roadSpawner;
    PlotSpawner plotSpawner;
    ObstacleSpawner obstacleSpawner;
    private int currTriggerCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        roadSpawner = GetComponent<RoadSpawner>();
        plotSpawner = GetComponent<PlotSpawner>();
        obstacleSpawner = GetComponent<ObstacleSpawner>();

        obstacleSpawner.InitializeObstacles(); // Initialize obstacles at the start
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnTriggerEntered()
    {
        currTriggerCount += 1;
        roadSpawner.MoveRoad();
        plotSpawner.SpawnPlot();

        if (currTriggerCount >= 2)
            obstacleSpawner.SpawnObstacles();
    }
}
