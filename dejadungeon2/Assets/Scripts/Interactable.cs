using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public UnityEvent interactedEvent;
    
    public void Interact()
    {
        interactedEvent.Invoke();
    }
}
