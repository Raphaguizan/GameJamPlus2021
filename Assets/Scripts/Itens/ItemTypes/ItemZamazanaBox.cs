using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Item
{
    [CreateAssetMenu(fileName = "ZamazanaBox", menuName = "Game/Item/ZamazanaBox")]
    public class ItemZamazanaBox : ItemBase, IUseItem
    {
        public void Use()
        {
            Debug.Log("Usou Zamazana");
        }
    }
}

