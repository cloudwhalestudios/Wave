using PlayerPreferences;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlatformPreferences
{
    static PlatformPreferences current;
    static bool hasLoaded = false;

    [SerializeField] bool completedSetup;
    [SerializeField] KeyCode[] keys;
    [SerializeField] float menuProgressionTimer = 5f;
    [SerializeField] float platformVolumeLevel = -1f;
    [SerializeField] bool platformMute = false;

    [SerializeField] float gameVolumeLevel = -1f;
    [SerializeField] bool gameMute = false;

    public static PlatformPreferences Current
    {
        get
        {
            if (current != null)
                return current;

            current = PlayerPreferenceManager.Load<PlatformPreferences>();
            return current;
        }
        set
        {
            if (!hasLoaded)
            {
                Debug.Log("Setting up platform preferences: " + value + " (Json: " + JsonUtility.ToJson(value, true) + ")");
                current = value;
                hasLoaded = true;
            }
        }
    }

    public bool CompletedSetup { get => completedSetup; set { completedSetup = value; Save(); } }
    public KeyCode[] Keys { get => keys; set { keys = value; Save(); } }
    public float ReactionTime { get => menuProgressionTimer; set { menuProgressionTimer = value; Save(); } }
    public float PlatformVolumeLevel { get => platformVolumeLevel; set { platformVolumeLevel = value; Save(); } }
    public float GameVolumeLevel { get => gameVolumeLevel; set { gameVolumeLevel = value; Save(); } }

    public bool PlatformMute
    {
        get => platformMute; set
        {
            platformMute = value;
            Save();
        }
    }
    public bool GameMute
    {
        get => gameMute; set
        {
            gameMute = value;
            Save();
        }
    }

    public static void Save()
    {
        PlayerPreferenceManager.Save(current);
    }
}
