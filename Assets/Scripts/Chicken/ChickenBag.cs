using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Util;
using Game.Item;

namespace Game.Chicken
{
    public class ChickenBag : Singleton<ChickenBag>
    {
        public SO_Bag itemList;
        public static Action UpdateInterface;
        public RequiredItemUI itemBaloon;

        private readonly int MAX_ITEM = 6;

        public void AddItem(ItemBase item)
        {
            //FIX colocar código mais genérico
            if (item is IUseItem)
            {
                Debug.Log("Item Usável : "+ item.name);
                (item as IUseItem).Use();
            }
            else if (itemList.itens.Count < MAX_ITEM)
            {
                Debug.Log("Item Colecionavel : " + item.name);
                itemList.itens.Add((item as ItemCollectable));
                UpdateInterface?.Invoke();
            }
            else
            {
                Debug.Log("n�o h� espa�o para mais itens");
            }
        }

        public bool RemoveItem(ItemCollectable item)
        {
            bool removed = itemList.itens.Remove(item);
            if (removed)
            {
                UpdateInterface?.Invoke();
            }
            return removed;
        }

        public bool VerifyItem(ItemCollectable item)
        {
            bool Exists = itemList.itens.Exists(i => i.Equals(item));
            if (!Exists)
            { 
                itemBaloon.ShowBaloon(item.image);
                Debug.Log("você nâo tem esse item");
            }
            return Exists;
        }

        private void OnApplicationQuit()
        {
            itemList.Reset();
        }

    }

}
