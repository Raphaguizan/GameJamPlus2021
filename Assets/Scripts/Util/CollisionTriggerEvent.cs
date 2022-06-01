using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollisionTriggerEvent : MonoBehaviour
{
    [SerializeField, NaughtyAttributes.Tag]
    private string playerTag = "Player";

    [Space]
    public UnityEvent OnCollide;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            OnCollide.Invoke();
        }
    }
}
