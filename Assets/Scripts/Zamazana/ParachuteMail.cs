using System;
using UnityEngine;


[CreateAssetMenu(fileName = "parachuteMail", menuName = "Game/Item/Give/Parachute")]
public class ParachuteMail : ScriptableObject
{
    public Action ParachuteGiveCallBack;
    public void Give()
    {
        ParachuteGiveCallBack?.Invoke();
    }
}
