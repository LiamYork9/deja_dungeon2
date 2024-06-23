using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public static bool keyPickedUp = false;

    public void ResetObject()
    {
        keyPickedUp = false;
        gameObject.SetActive(true);
    }

    public void TryPickUp()
    {
        if (keyPickedUp) return;
        keyPickedUp = true;
        gameObject.SetActive(false);
    }
}
