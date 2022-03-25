using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Item
{
    [CreateAssetMenu(fileName = "Boots", menuName = "Game/Item/Boot")]
    public class ItemBoot : ItemBase, IUseItem
    {
        public void Use()
        {
            Debug.Log("Usou a bota");
        }
    }
}

