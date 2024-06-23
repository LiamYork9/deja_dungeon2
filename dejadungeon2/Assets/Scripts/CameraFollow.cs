using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float zoom = 10f;
    Vector3 inputOffset = Vector3.zero;
    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        inputOffset = Vector3.Lerp(inputOffset, moveInput, Time.deltaTime);
        transform.position = target.position - new Vector3(0,0,zoom) + inputOffset;
    }
}
