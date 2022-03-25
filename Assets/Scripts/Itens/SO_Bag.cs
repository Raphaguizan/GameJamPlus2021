using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Item;

[CreateAssetMenu (fileName ="myBag", menuName ="Game/Bag")]
public class SO_Bag : ScriptableObject
{
    public List<ItemCollectable> itens;
}
