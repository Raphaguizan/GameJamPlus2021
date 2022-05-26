using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Chicken;

public class InsideBuildingVertical : MonoBehaviour
{
    Transform chicken;
    public List<GameObject> upObjs;
    public List<GameObject> downObjs;
    private void OnEnable()
    {
        chicken = GameObject.FindObjectOfType<Chicken>().transform;
    }
    private void Update()
    {
        if (chicken == null) return;
        if(chicken.position.y >= transform.position.y)
        {
            foreach(GameObject go in upObjs) go.SetActive(true);
            foreach(GameObject go in downObjs) go.SetActive(false);

        }
        else
        {
            foreach (GameObject go in upObjs) go.SetActive(false);
            foreach (GameObject go in downObjs) go.SetActive(true);
        }
    }
}
