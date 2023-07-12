using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Utils : MonoBehaviour
{
    public static Vector3 GetMousePosition(Transform target)
    {
        float targetDistance = Vector3.Distance(Camera.main.transform.position, target.position);
        Vector3 mousePos = Mouse.current.position.ReadValue();
        mousePos.z = targetDistance;//Camera.main.nearClipPlane;
        Vector3 Worldpos = Camera.main.ScreenToWorldPoint(mousePos);
        return Worldpos;
    }
}
