using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Item;

[CreateAssetMenu(fileName = "Dialog", menuName = "Game/Dialog")]
public class SO_Dialog : ScriptableObject
{
    public int id;
    public bool initial;
    public string question;
    public List<string> answer = new List<string>(4);
    public List<string> replica = new List<string>(4);
    [Space]
    public bool hasItem = true;
    public ItemBase item;
    public int itemAnswer = -1;
}
