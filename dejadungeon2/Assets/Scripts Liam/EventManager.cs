using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventManager : MonoBehaviour
{
    public static event Action ResetEvent;
    BoxCollider2D player;
    public LayerMask mask;

    public bool Reset = true;

    void Awake()
    {
        ResetEvent = null;
        player = FindFirstObjectByType<PlayerController>().GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (Reset == true)
        {
            if (Input.GetKeyDown(KeyCode.R) /*&& !CheckForOverlap()*/)
            {
                ResetEvent?.Invoke();
            }
        }

        if (PauseMenu.GameIsPaused)
        {
            Reset = false;
        }

        if (PauseMenu.GameIsPaused == false)
        {
            Reset = true;
        }
    }

    bool CheckForOverlap()
    {
        print(player.IsTouchingLayers(mask.value));
        return player.IsTouchingLayers(mask.value);
    }

    
}
