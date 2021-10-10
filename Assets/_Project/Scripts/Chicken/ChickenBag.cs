using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Util;

public class ChickenBag : Singleton<ChickenBag>
{
    public SO_Bag itemList;
    public static Action UpdateInterface;

    private void Start()
    {
        itemList.itens = new List<ItemBase>();
    }

    public void AddItem(ItemBase item)
    {
        itemList.itens.Add(item);
        UpdateInterface?.Invoke();
    }

    public void RemoveItem(ItemBase item)
    {
        itemList.itens.Remove(item);
        UpdateInterface?.Invoke();
    }

}
