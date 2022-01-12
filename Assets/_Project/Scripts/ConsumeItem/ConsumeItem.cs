using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ConsumeItem : MonoBehaviour
{
    public ItemBase item;
    public Outline outline;
    public float outlineWidth = 2f;
    public UnityEvent Event;

    protected void Start()
    {
        outline.OutlineWidth = 0f;
    }
    protected void OnTriggerEnter(Collider other)
    {
        var player = other.gameObject.GetComponent<Chicken>();
        if (player)
        {
            outline.OutlineWidth = outlineWidth;
        }
    }
    protected void OnTriggerExit(Collider other)
    {
        var player = other.gameObject.GetComponent<Chicken>();
        if (player)
        {
            outline.OutlineWidth = 0f;
        }
    }

    public virtual void CheckItem() 
    {
        if (!item)
        {
            Event?.Invoke();
            return;
        }
        if (ChickenBag.Instance.RemoveItem(item))
        {
            Event?.Invoke();
        }
    } 
}
