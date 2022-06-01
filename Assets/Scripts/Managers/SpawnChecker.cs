using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.SpawnPos;

public class SpawnChecker : MonoBehaviour
{
    public GamePositionSpawnManager spawnPos;
    public GameObject Karen;

    private void OnEnable()
    {
        Karen.transform.position = spawnPos.GetSpawnPos();
    }
}
