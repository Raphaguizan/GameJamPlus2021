using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.SpawnPos;
using Game.Chicken;
using NaughtyAttributes;

public class SpawnChecker : MonoBehaviour
{
    public GamePositionSpawnManager spawnPos;
    [SerializeField]
    private bool onlyOneSpawn = false;

    [SerializeField, ShowIf("onlyOneSpawn")]
    private int spawnIndex;

    private void OnEnable()
    {
        Spawn();
    }

    public void Spawn()
    {
        if (onlyOneSpawn)
        {
            ChickenPowerUps.Instance.transform.position = spawnPos.GetSpawnPos(spawnIndex);
            return;
        }
        ChickenPowerUps.Instance.transform.position = spawnPos.GetSpawnPos();
    }
}
