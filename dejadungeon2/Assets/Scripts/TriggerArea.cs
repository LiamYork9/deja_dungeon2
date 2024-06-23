using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerArea : MonoBehaviour
{
    public UnityEvent entered;
    public bool onlyAllowPlayer;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (onlyAllowPlayer && collision.gameObject.tag != "Player") return;
        entered.Invoke();
    }
}
