using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebGLIntegration;

public class BootLoader : MonoBehaviour
{
    public static void FetchPreferences()
    {
        var jsonString = JSLib.GetParams();
        Debug.Log("Loaded parameters: " + JsonUtility.ToJson(jsonString, true));

        PlatformPreferences.Current = JsonUtility.FromJson<PlatformPreferences>(jsonString);
    }
}
