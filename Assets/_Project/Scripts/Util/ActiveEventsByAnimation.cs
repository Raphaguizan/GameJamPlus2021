using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ActiveEventsByAnimation : MonoBehaviour
{
    public UnityEvent Event;

    public void CallEvent()
    {
        Event?.Invoke();
    }
}
