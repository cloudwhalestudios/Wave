using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{

    public GameObject PlyerObj;
    public GameObject[] Obstacles;
    private int ObstacleCount;

    int ObstacleIndex = 0;
    public int DistanceToNext = 50;

    GameObject FirstOne;
    GameObject SecondOne;

    int playerPositionIndex = -1;


    void Start()
    {
        InstantiateObstacle();
    }

    void Update()
    {
        if (playerPositionIndex != (int)PlyerObj.transform.position.y / 25)
        {
            InstantiateObstacle();
            playerPositionIndex = (int)PlyerObj.transform.position.y / 25;
        }
    }

    public void InstantiateObstacle()
    {
        ObstacleCount = Obstacles.Length;
        int FirstObstacleNumber = Random.Range(0, 7);
        GameObject NewObs = Instantiate(Obstacles[FirstObstacleNumber], new Vector3(0, ObstacleIndex * DistanceToNext), Quaternion.identity); // Change to Obstacles[FirstObstacleNumber]
        NewObs.transform.SetParent(transform);
        ObstacleIndex++;
    }
}