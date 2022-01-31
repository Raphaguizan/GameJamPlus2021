using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : ItemCollectableBase
{
    public GameObject itemPrefab;

    private bool hasItem = true;

    private void OnEnable()
    {
        outline.enabled = true;
    }
    public override void Collect()
    {
        if (hasItem)
        {
            Instantiate(itemPrefab, transform.position*1.1f, transform.rotation, null);
            hasItem = false;
        }
    }

    private void OnDisable()
    {
        outline.enabled = false;
    }

}
