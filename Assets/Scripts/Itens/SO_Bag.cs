using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName ="myBag", menuName ="Game/Bag")]
public class SO_Bag : ScriptableObject
{
    public List<ItemBase> itens;
}
