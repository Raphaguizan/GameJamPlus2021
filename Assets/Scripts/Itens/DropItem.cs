using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : ItemCollectableBase
{
    public GameObject itemPrefab;
    public Collider triggerSphere;

    private bool hasItem = true;

    private void OnEnable()
    {
        outline.enabled = true;
        //triggerSphere.enabled = true;
    }
    public override void Collect()
    {
        if (hasItem && this.enabled == true)
        {
            Instantiate(itemPrefab, transform.position*1.1f, transform.rotation, null);
            hasItem = false;
        }
    }

    private void OnDisable()
    {
        outline.enabled = false;
       // triggerSphere.enabled = false;
    }

}
