using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenPowerUpKungFu : ChickenPowerUpBase
{
    [SerializeField]
    private HitController chickenHit;

    protected override void Start()
    {
        base.Start();
        _name = PowerUpType.KUNGFU;
    }

    public override void Interact()
    {
        chickenHit.Hit();
    }
}
