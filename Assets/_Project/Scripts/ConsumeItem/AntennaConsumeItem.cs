using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntennaConsumeItem : ConsumeItem
{
    public override void CheckItem()
    {
        if (ChickenBag.Instance.RemoveItem(item) && !TimeController._isDay)
        {
            Event?.Invoke();
        }
    }
}
