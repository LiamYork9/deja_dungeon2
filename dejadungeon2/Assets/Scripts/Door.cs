using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public void ResetObject()
    {
        gameObject.SetActive(true);
    }

    public void TryOpen()
    {
        if (Key.keyPickedUp)
        {
            Key.keyPickedUp = false;
            gameObject.SetActive(false);
        }
    }
}
