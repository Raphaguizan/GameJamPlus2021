using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CornController : MonoBehaviour
{
    public Vector3 centerOfMass;
    private Rigidbody _myRB;

    void Start()
    {
        _myRB = GetComponent<Rigidbody>();
        _myRB.centerOfMass = centerOfMass;
    }
#if UNITY_EDITOR
    private void OnValidate()
    {
        _myRB = GetComponent<Rigidbody>();
        _myRB.centerOfMass = centerOfMass;
    }
#endif
}

