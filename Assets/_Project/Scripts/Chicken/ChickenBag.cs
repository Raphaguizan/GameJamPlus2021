using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Util;

public class ChickenBag : Singleton<ChickenBag>
{
    public SO_Bag itemList;
    public static Action UpdateInterface;

    private readonly int MAX_ITEM = 6;

    private void Start()
    {
        itemList.itens = new List<ItemBase>();
    }

    public void AddItem(ItemBase item)
    {
        if(itemList.itens.Count < MAX_ITEM)
        {
            itemList.itens.Add(item);
            UpdateInterface?.Invoke();
        }
        else
        {
            Debug.Log("não há espaço para mais itens");
        }
    }

    public bool RemoveItem(ItemBase item)
    {
        bool removed = itemList.itens.Remove(item);
        if (removed)
        {
            UpdateInterface?.Invoke();
        }
        else
        {
            Debug.Log("você não tem esse item");
        }
        return removed;
    }

}
