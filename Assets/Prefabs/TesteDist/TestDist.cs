using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class TestDist : MonoBehaviour
{
    public Transform point1;
    public Transform point2;

    [Button]
    public void ShowDist()
    {
        Debug.Log(Vector3.Distance(point1.position, point2.position));
    }
}
