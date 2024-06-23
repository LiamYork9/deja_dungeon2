using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventManager : MonoBehaviour
{
    public static event Action ResetEvent;
    BoxCollider2D player;
    public LayerMask mask;

    void Awake()
    {
        ResetEvent = null;
        player = FindFirstObjectByType<PlayerController>().GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && !CheckForOverlap())
        {
            ResetEvent?.Invoke();
        }
    }

    bool CheckForOverlap()
    {
        print(player.IsTouchingLayers(mask.value));
        return player.IsTouchingLayers(mask.value);
    }
}
