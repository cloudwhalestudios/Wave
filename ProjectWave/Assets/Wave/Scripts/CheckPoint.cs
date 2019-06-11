using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public bool selected;
    public SpriteRenderer selectedVisual;

    private GameObject[] Checkpoints;

    private Vector3 CurrentPosition;

    void Start()
    {
        selectedVisual = GetComponent<SpriteRenderer>();

        Checkpoints = GameObject.FindGameObjectsWithTag("Checkpoint");
        ForEveryCheckpoint();
    }

    void Update()
    {
        if (selected)
        {
            selectedVisual.enabled = true;
        } else
        {
            selectedVisual.enabled = false;
        }
    }

    void ForEveryCheckpoint()
    {
        CurrentPosition = this.gameObject.transform.position;
        //print(CurrentPosition);
        for (var i = 0; i < Checkpoints.Length; i++)
        {
            if (this.gameObject.transform.position == Checkpoints[i].gameObject.transform.position && Checkpoints[i] != this.gameObject)
            {
                //print(Checkpoints[i].gameObject.transform.position);
            }
        }
    }
}