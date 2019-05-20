﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    public GameObject fx_Dead;
    public GameObject fx_ColorChange;
    GameObject GameManagerObj;

    [Space]
    public AudioClip DeadClip;
    public AudioClip ItemClip;
    AudioSource source;



    Rigidbody2D rb;

    float angle = 0;

    [Space]
    public float Xspeed;

    public int YaccelerationForce;
    public int YdecelerationForce;
    public int YspeedMax;
    float hueValue;
    public bool isDead = false;

    [SerializeField] KeyCode primaryKey;
    [SerializeField] KeyCode secondaryKey;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            DestroyImmediate(Instance);
            Instance = this;
        }
    }
    void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }

    void Start()
    {
        GameManagerObj = GameObject.Find("GameManager");
        rb = GetComponent<Rigidbody2D>();
        source = GetComponent<AudioSource>();

        hueValue = Random.Range(0, 10) / 10.0f;
        SetBackgroundColor();

        if (PlatformPreferences.Current?.Keys != null)
        {
            primaryKey = PlatformPreferences.Current.Keys[0];
            secondaryKey = PlatformPreferences.Current.Keys[1];
        }
        else if (primaryKey == KeyCode.None || secondaryKey == KeyCode.None)
        {
            primaryKey = KeyCode.LeftArrow;
            secondaryKey = KeyCode.RightArrow;
        }
    }


    void Update()
    {
        if (isDead) return;
        MovePlayer();
    }


    void MovePlayer()
    {

        Vector2 pos = transform.position;
        pos.x = Mathf.Cos(angle) * (GameManagerObj.GetComponent<DisplayManager>().RIGHT * 0.9f);
        pos.y += 0.002f;
        transform.position = pos;
        angle += Time.deltaTime * Xspeed;


        if (Input.GetKey(primaryKey) || Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            if (rb.velocity.y < YspeedMax)
            {
                rb.AddForce(new Vector2(0, YaccelerationForce));
            }
        }
        else
        {
            if (rb.velocity.y > 0)
            {
                rb.AddForce(new Vector2(0, -YdecelerationForce));
            }
            else
            {
                rb.velocity = new Vector2(rb.velocity.x, 0);
            }
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Item_ColorChange")
        {
            Destroy(Instantiate(fx_ColorChange, other.gameObject.transform.position, Quaternion.identity), 0.5f);
            Destroy(other.gameObject.transform.parent.gameObject);
            SetBackgroundColor();

            GameManagerObj.GetComponent<GameManager>().addScore();

            source.PlayOneShot(ItemClip, 1);
        }

        if (other.gameObject.tag == "Obstacle" && isDead == false)
        {
            isDead = true;

            Destroy(Instantiate(fx_Dead, transform.position, Quaternion.identity), 0.5f);
            StopPlayer();
            GameManagerObj.GetComponent<GameManager>().Gameover();

            source.PlayOneShot(DeadClip, 1);
            AudioManager.Instance.PlaySoundNormally(AudioManager.Instance.Death);
        }
    }



    void StopPlayer()
    {
        rb.velocity = new Vector2(0, 0);
        rb.isKinematic = true;
    }


    void SetBackgroundColor()
    {
        hueValue += 0.1f;
        if (hueValue >= 1)
        {
            hueValue = 0;
        }
        Camera.main.backgroundColor = Color.HSVToRGB(hueValue, 0.6f, 0.8f);
    }


}
