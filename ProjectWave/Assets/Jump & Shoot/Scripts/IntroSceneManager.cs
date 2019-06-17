using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroSceneManager : MonoBehaviour {

    [Header("Boot Options")]
    public float minBootDelay = 0f;

    bool finishedLoading = false;


    private void Start()
    {
        //AudioManager.Instance.PlaySoundNormally(AudioManager.Instance.Launch);
        StartCoroutine(StartNextScene());

        // Load the platform preferences
        LoadUserSetup();
    }

    private void LoadUserSetup()
    {
        BootLoader.FetchPreferences();
        finishedLoading = true;
    }

    IEnumerator StartNextScene()
    {
        yield return new WaitForSeconds(minBootDelay);

        if (!finishedLoading)
        {
            yield return new WaitForEndOfFrame();
        }

        SceneManager.LoadScene("MainMenu");
        yield break;
    }
}
