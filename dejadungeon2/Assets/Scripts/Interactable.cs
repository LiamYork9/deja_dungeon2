using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class Vector2Event : UnityEvent<Vector2> { }

public class Interactable : MonoBehaviour
{
    public Vector2Event interactedEvent;
    
    public void Interact(Vector2 facing)
    {
        interactedEvent.Invoke(facing);
    }
}
