using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateForEver : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        transform.Rotate(new Vector3(0,speed * Time.deltaTime,0));
    }
}
