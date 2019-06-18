using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonContainer : MonoBehaviour
{
    public UnityEvent enableEvents;
    public UnityEvent disableEvents;

    private void OnEnable()
    {
        enableEvents?.Invoke();
    }

    private void OnDisable()
    {
        disableEvents.Invoke();
    }
}
