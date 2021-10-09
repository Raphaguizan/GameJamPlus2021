using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    [Range(0f,24f)]
    public float time;
    public float timeSpeed;
    public Transform mainLight;


    public static bool _isDay;
    public static Action TimeChange;
    // Start is called before the first frame update
    void Start()
    {
        _isDay = true;
    }

    // Update is called once per frame
    void Update()
    {
        time += timeSpeed/10 * Time.deltaTime;
        if (time >= 24f) time = 0;
        if(time >= 6 && time < 18)
        {
            _isDay = true;
            TimeChange?.Invoke();
        }
        else
        {
            _isDay = false;
            TimeChange?.Invoke();
        }
        RotateLightByTime();
    }
    private void OnValidate()
    {
        RotateLightByTime();
    }

    private void RotateLightByTime()
    {
        mainLight.localEulerAngles = new Vector3(Remap(time, 6, 18, 0, 180), 20, mainLight.localRotation.z);
    }

    float Remap(float s, float a1, float a2, float b1, float b2)
    {
        return b1 + (s - a1) * (b2 - b1) / (a2 - a1);
    }
}
