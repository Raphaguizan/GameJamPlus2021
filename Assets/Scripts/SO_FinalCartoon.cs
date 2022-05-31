using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Game/Final", fileName ="FinalCartoon")]
public class SO_FinalCartoon : ScriptableObject
{
    [SerializeField]
    private bool _isCartoon = false;

    public bool IsCartoon => _isCartoon;

    public void ResetFinalCartoon()
    {
        _isCartoon = false;
    }

    public void ActiveFinalCartoon()
    {
        _isCartoon = true;
    }
}
