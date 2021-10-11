using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectableBase : MonoBehaviour
{
    public ItemBase item;
    public Outline outline;
    private void Start()
    {
        outline.OutlineWidth = 0f;
    }
    private void OnTriggerEnter(Collider other)
    {
        var player = other.gameObject.GetComponent<Chicken>();
        if (player)
        {
            outline.OutlineWidth = 1f;
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

    public virtual void Collect()
    {
        Destroy(gameObject);
        OnCollet();
    }


    protected virtual void OnCollet()
    {
        ChickenBag.Instance.AddItem(item);
    }
}
