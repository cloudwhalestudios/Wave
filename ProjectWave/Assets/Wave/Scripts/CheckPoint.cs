using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public bool selected;
    public SpriteRenderer selectedVisual;


    void Start()
    {
        selectedVisual = GetComponent<SpriteRenderer>();
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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Checkpoint")
        {
            print("Checkpoint stuck in each other");
        }
    }
}