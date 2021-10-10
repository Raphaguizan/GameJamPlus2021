using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FallFinal : MonoBehaviour
{
    public UnityEvent Event;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player"))
        {
            Event?.Invoke();
        }
    }
}
