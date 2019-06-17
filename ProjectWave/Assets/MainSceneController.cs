using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainSceneController : MonoBehaviour
{
    [Header("References")]
    public RectTransform buttonParent;
    public RectTransform indicator;
    public RectTransform timer;
    public Vector3 indicatorOffset;

    int selectedIndex = 0;
    List<Button> buttons;


    public void StartIndicating()
    {
        buttons = new List<Button>(buttonParent.GetComponentsInChildren<Button>());
        UpdateIndicatorPosition();

        StartCoroutine(IndicateMenuOptionRoutine());
    }

    public void StopIndicating()
    {
        StopAllCoroutines();
    }

    private void UpdateIndicatorPosition()
    {
        var btn = buttons[selectedIndex].transform;
        indicator.SetParent(btn);
        indicator.localPosition = indicatorOffset;
    }

    private void Update()
    {
        if (Input.GetKeyDown(Player.Instance.secondaryKey))
        {
            OpenMainMenu();
        }
        else if (buttonParent.gameObject.activeInHierarchy && Input.GetKeyDown(Player.Instance.primaryKey))
        {
            SelectCurrentButton();
        }
    }

    private void SelectCurrentButton()
    {
        buttons[selectedIndex].onClick?.Invoke();
    }

    private IEnumerator IndicateMenuOptionRoutine()
    {
        while (true)
        {
            var elapsedTime = 0f;
            var scale = new Vector3(0, 1, 1);
            timer.localScale = scale;
            while (elapsedTime < Player.Instance.indicateTime)
            {
                scale.x = Mathf.Lerp(0f, 1f, elapsedTime / Player.Instance.indicateTime);
                Debug.Log(scale);
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

    public void OpenMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
