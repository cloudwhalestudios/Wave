using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeterManager : MonoBehaviour
{
    public GameObject PlayerObject;
    public GameObject MeterBar;

    private int ObstacleIndex = 0;
    public int DistanceToNext = 50;

    public int YUnitDistance = 5;

    private int playerPositionIndex = -1;

    void Start()
    {
        CreateMeterBar();
    }

    void Update()
    {
        if (playerPositionIndex != (int)PlayerObject.transform.position.y / YUnitDistance)
        {
            CreateMeterBar(); //Creates a prefab object
            playerPositionIndex = (int)PlayerObject.transform.position.y / YUnitDistance;
        }
    }

    void CreateMeterBar()
    {
        GameObject NewBar = Instantiate(MeterBar, new Vector3(0, ObstacleIndex * DistanceToNext), Quaternion.identity);
        NewBar.transform.SetParent(transform);
        ObstacleIndex++;
    }
}
