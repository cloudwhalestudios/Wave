using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDeletionScript : MonoBehaviour
{
    public GameObject GameObjectDeletion;


    // Use this for initialization
    void Start()
    {
        GameObjectDeletion = GameObject.Find("GameObjectDeletion");
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < GameObjectDeletion.transform.position.y)
        {
            Destroy(gameObject);
        }
    }

    /*
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
    */
    // Didn't work because it interferes with the player collision in relation to obstacles. 
    // The player suddenly detects the ObjectDeletion hitbox as its own.
}
