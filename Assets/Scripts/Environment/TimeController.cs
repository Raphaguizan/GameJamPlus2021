using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Util;

public class TimeController : Singleton<TimeController>
{
    [Range(0f,24f)]
    public float time;
    public bool RunTime = false;
    public Gradient iluminationColor;
    public float timeSpeed;
    [Space]
    public Transform mainLight;
    public Light dayLight;
    public Light nightLight;

    public static bool IsDay;
    public static Action TimeChange;
    public static Color GetTimeColor() => Instance.GetColor();


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
        DayAndNightController();
        RotateLightByTime();
        AdjustColors();
    }

    public static void SetTime(float val)
    {
        if (val > 24)
            val = 24;
        else if (val < 0)
            val = 0;

        Instance.time = val;
    }
    private void AdjustColors()
    {
        Color currentColor = GetColor();
        dayLight.color = currentColor;
        nightLight.color = currentColor;
    }

    
    private Color GetColor()
    {
        float value = time.Remap(0, 24, 0, 1);
        return iluminationColor.Evaluate(value);
    }

    private void DayAndNightController()
    {
        if (time >= 24f) time = 0;
        if (time >= 6 && time < 18 && !IsDay)
        {
            IsDay = true;
            TimeChange?.Invoke();
            AdjustMainLight();
        }
        else if ((time < 6 || time >= 18) && IsDay)
        {
            IsDay = false;
            TimeChange?.Invoke();
            AdjustMainLight();
        }
    }
    private void AdjustMainLight()
    {
        if (IsDay)
        {
            dayLight.enabled = true;
            nightLight.enabled = false;
        }
        else
        {
            nightLight.enabled = true;
            dayLight.enabled = false;
        }
    }

    private void RotateLightByTime()
    {
        if (!mainLight) return;
        mainLight.localEulerAngles = new Vector3(time.Remap(6, 18, 0, 180), 20, mainLight.localRotation.z);
    }

#if UNITY_EDITOR
    private void OnValidate()
    {
        RotateLightByTime();
        DayAndNightController();
        AdjustColors();
    }
#endif
}
