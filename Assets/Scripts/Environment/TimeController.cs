using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Util;

[ExecuteInEditMode]
public class TimeController : Singleton<TimeController>
{
    [Range(0f,24f)]
    public float time;
    public bool RunTime = false;
    public Gradient iluminationColor;
    public float timeSpeed;
    public Transform mainLight;


    public static bool IsDay;
    public static Action TimeChange;

    private void OnEnable()
    {
        GameManager.UnloadScene += ResetColors;
    }
    private void OnDisable()
    {
        RunTime = false;
        GameManager.UnloadScene -= ResetColors;
    }
    // Start is called before the first frame update
    void Start()
    {
        IsDay = true;
        RunTime = true;
        TimeChange?.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        if(RunTime)time += timeSpeed/10 * Time.deltaTime;
        if (time >= 24f) time = 0;
        if(time >= 6 && time < 18 && !IsDay)
        {
            IsDay = true;
            TimeChange?.Invoke();
        }
        else if((time < 6 || time >= 18) && IsDay)
        {
            IsDay = false;
            TimeChange?.Invoke();
        }
        RotateLightByTime();
        AdjustColors();
    }


    private void AdjustColors()
    {
        float value = time.Remap(0, 24, 0, 1);
        Color currentColor = iluminationColor.Evaluate(value);
        Shader.SetGlobalColor("_LightColor", currentColor);
    }

    private void ResetColors()
    {
        Shader.SetGlobalColor("_LightColor", Color.white);
    }

    private void OnValidate()
    {
        RotateLightByTime();
        AdjustColors();
    }

    private void RotateLightByTime()
    {
        mainLight.localEulerAngles = new Vector3(time.Remap(6, 18, 0, 180), 20, mainLight.localRotation.z);
    }
}
