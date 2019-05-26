using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeterManager : MonoBehaviour
{
    public GameObject PlayerObject;
    public GameObject MeterBar;
    public Text MeterText;
    public Canvas RenderCanvas;

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
        Vector3 NewMeterPos = new Vector3(0, ObstacleIndex * DistanceToNext);
        GameObject NewBar = Instantiate(MeterBar, NewMeterPos, Quaternion.identity);

        Text tempTextBox = Instantiate(MeterText, (NewMeterPos * 23), Quaternion.identity) as Text;

        //Parent to the panel
        tempTextBox.transform.SetParent(RenderCanvas.transform, false);
        // Set the text box's text element font size and style:
        // tempTextBox.fontSize = defaultFontSize;*/

        //Set the text box's text element to the current textToDisplay:
        tempTextBox.text = (ObstacleIndex * DistanceToNext) + "M";

        NewBar.transform.SetParent(transform);
        ObstacleIndex++;
    }
}
