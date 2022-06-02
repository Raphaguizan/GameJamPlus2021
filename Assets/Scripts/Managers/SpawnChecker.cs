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

    private GameObject chicken;
    private void Awake()
    {
        chicken = GameObject.FindObjectOfType<Chicken>().gameObject;
    }

    private void OnEnable()
    {
        chicken.GetComponent<Rigidbody>().isKinematic = true;
        ScreenTransition.OnStart += FreeKinematic;
        Spawn();
    }

    public void Spawn()
    {
        if (onlyOneSpawn)
        {
            chicken.transform.position = spawnPos.GetSpawnPos(spawnIndex);
            return;
        }
        chicken.transform.position = spawnPos.GetSpawnPos();
    }

    private void FreeKinematic()
    {
        chicken.GetComponent<Rigidbody>().isKinematic = false;
    }
    private void OnDisable()
    {
        ScreenTransition.OnStart -= FreeKinematic;
    }
}
