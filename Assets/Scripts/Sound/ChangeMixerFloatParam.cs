using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class ChangeMixerFloatParam : MonoBehaviour
{
    public AudioMixer mixer;
    public string ParamName;
    public float value;

    private float oldValue;
    private void OnEnable()
    {
        mixer.GetFloat(ParamName, out float val);
        oldValue = val;
        mixer.SetFloat(ParamName, value);
    }
    private void OnDisable()
    {
        mixer.SetFloat(ParamName, oldValue);
    }

}
