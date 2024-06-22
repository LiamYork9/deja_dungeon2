using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventManager : MonoBehaviour
{
    public static event Action ResetEvent;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetEvent?.Invoke();
        }
    }
}
