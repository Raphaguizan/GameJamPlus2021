using Game.Chicken;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenPowerUpBoots : ChickenPowerUpBase
{
    [SerializeField]
    private ChickenAsset chicken;
    [SerializeField] 
    private float bootsJumpForce = 6f;

    protected override void Start()
    {
        base.Start();
        _name = PowerUpType.BOOTS;
    }

    public override void ActivePowerUp()
    {
        base.ActivePowerUp();
        chicken.ChickenScript.JumpForce = bootsJumpForce;
    }
}
