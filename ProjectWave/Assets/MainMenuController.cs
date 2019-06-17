using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using WebGLIntegration;

public class MainMenuController : MonoBehaviour
{
    [Header("Preferences")]
    public bool usePreferences = true;
    public KeyCode primaryKey;
    public KeyCode secondaryKey;
    public float indicateTime = 2f;

    [Header("References")]
    public RectTransform buttonParent;
    public RectTransform indicator;
    public RectTransform timer;
    public Vector3 indicatorOffset;

    int selectedIndex = 0;
    List<Button> buttons;

    // Start is called before the first frame update
    void Start()
    {
        if (usePreferences && PlatformPreferences.Current.Keys != null)
        {
            primaryKey = PlatformPreferences.Current.Keys[0];
            secondaryKey = PlatformPreferences.Current.Keys[1];
        }

        if (usePreferences && PlatformPreferences.Current.ReactionTime > 0)
        {
            indicateTime = PlatformPreferences.Current.ReactionTime;
        }

        buttons = new List<Button>(buttonParent.GetComponentsInChildren<Button>());
        UpdateIndicatorPosition();

        StartCoroutine(IndicateMenuOptionRoutine());
    }

    private void UpdateIndicatorPosition()
    {
        var btn = buttons[selectedIndex].transform;
        indicator.SetParent(btn);
        indicator.localPosition = indicatorOffset;
    }

    private void Update()
    {
        if (Input.GetKeyDown(secondaryKey))
        {
            ExitGame();
        }
        else if (Input.GetKeyDown(primaryKey))
        {
            SelectCurrentButton();
        }
    }

    private void SelectCurrentButton()
    {
        buttons[selectedIndex].onClick?.Invoke();
    }

    public void Play()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void ExitGame()
    {
        WebGLRedirect.OpenLauncher();
    }

    private IEnumerator IndicateMenuOptionRoutine()
    {
        while (true)
        {
            var elapsedTime = 0f;
            var scale = new Vector3(0, 1, 1);
            timer.localScale = scale;
            while (elapsedTime <  indicateTime)
            {
                scale.x = Mathf.Lerp(0f, 1f, elapsedTime / indicateTime);
                //Debug.Log(scale);
                timer.localScale = scale;

                yield return null;
                elapsedTime += Time.unscaledDeltaTime;
            }
            timer.localScale = new Vector3(1, 1, 1);
            yield return null;

            selectedIndex = (selectedIndex + 1) % buttons.Count;
            UpdateIndicatorPosition();
        }
    }
}
 