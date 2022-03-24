using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ChangeCenterOfMass : MonoBehaviour
{
    public Transform center;
    private Rigidbody myRB;
    void Start()
    {
        myRB = GetComponent<Rigidbody>();
        myRB.centerOfMass = center.position;
    }

}
