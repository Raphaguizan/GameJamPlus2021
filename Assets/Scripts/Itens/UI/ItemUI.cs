using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Game.Item;

public class ItemUI : MonoBehaviour
{
    public Image image;

    public void Initialize(ItemCollectable item)
    {
        image.sprite = item.image;
    }
}
