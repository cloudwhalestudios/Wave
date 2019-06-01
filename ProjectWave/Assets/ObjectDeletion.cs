using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDeletionScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "MeterBar")
        {
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Item_ColorChange")
        {
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Obstacle")
        {
            Destroy(other.gameObject);
        }
    }
}
