using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ConsumeItem : MonoBehaviour
{
    public ItemBase item;
    public Outline outline;
    public float outlineWidth = 0.8f;
    public UnityEvent Event;

    private void Start()
    {
        outline.OutlineWidth = 0f;
    }
    private void OnTriggerEnter(Collider other)
    {
        var player = other.gameObject.GetComponent<Chicken>();
        if (player)
        {
            outline.OutlineWidth = outlineWidth;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        var player = other.gameObject.GetComponent<Chicken>();
        if (player)
        {
            outline.OutlineWidth = 0f;
        }
    }

    public void CheckItem() 
    {
        if (ChickenBag.Instance.RemoveItem(item))
        {
            Event?.Invoke();
        }
    } 
}
