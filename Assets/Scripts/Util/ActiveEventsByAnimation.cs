using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ActiveEventsByAnimation : MonoBehaviour
{
    public UnityEvent Event;
    [Space]
    public List<UnityEvent> ListEvents;

    public void CallEvent()
    {
        Event?.Invoke();
    }

    public void CallEventByIndex(int i)
    {
        ListEvents[i]?.Invoke();
    }
}
