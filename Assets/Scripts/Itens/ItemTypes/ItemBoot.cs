using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Chicken;

namespace Game.Item
{
    [CreateAssetMenu(fileName = "Boots", menuName = "Game/Item/Boot")]
    public class ItemBoot : ItemBase, IUseItem
    {
        public void Use()
        {
            ChickenPowerUps.ActiveBoots();
        }
    }
}

