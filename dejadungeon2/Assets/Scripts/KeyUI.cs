using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyUI : MonoBehaviour
{
    public Image image;
    private void Update()
    {
        image.enabled = Key.keyPickedUp;
    }
}
