using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Game.Item;
using Game.Chicken;

public class ConsumeItem : MonoBehaviour
{
    public ItemCollectable item;
    public Outline outline;
    public UnityEvent Event;

    private float outline_initial_size = 2f;
    protected void Start()
    {
        outline_initial_size = outline.OutlineWidth;
        outline.OutlineWidth = 0f;
    }
    private void OnTriggerEnter(Collider other)
    {
        var player = other.gameObject.GetComponent<Chicken>();
        if (player && other.CompareTag("Player"))
        {
            outline.OutlineWidth = outline_initial_size;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var player = other.gameObject.GetComponent<Chicken>();
        if (player && other.CompareTag("Player"))
        {
            outline.OutlineWidth = 0f;
        }
    }

    public virtual void CheckItem() 
    {
        Debug.Log("cheking Item");
        if (item == null)
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
