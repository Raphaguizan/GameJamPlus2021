using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Item
{
    [CreateAssetMenu(fileName = "New Collectable Item", menuName = "Game/ItemColectable")]
    public class ItemCollectable : ItemBase
    {
        public Sprite image;
    }

}
