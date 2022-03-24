using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntennaConsumeItem : ConsumeItem
{
    public override void CheckItem()
    {
        if (!TimeController.IsDay && ChickenBag.Instance.RemoveItem(item))
        {
            Event?.Invoke();
        }
    }
}
