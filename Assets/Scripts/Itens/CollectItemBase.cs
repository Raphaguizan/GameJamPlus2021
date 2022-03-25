using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Item;
using Game.Chicken;

public class CollectItemBase : MonoBehaviour
{
    public ItemBase item;
    public Outline outline;

    private float outline_initial_size;
    private void Start()
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
