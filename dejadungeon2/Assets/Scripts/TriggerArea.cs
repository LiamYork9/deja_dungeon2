using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerArea : MonoBehaviour
{
    public UnityEvent entered;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        entered.Invoke();
    }
}
