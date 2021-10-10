using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Item", menuName = "Game/Item")]
public class ItemBase : ScriptableObject
{
    public int ID;
    public Sprite image;
}
