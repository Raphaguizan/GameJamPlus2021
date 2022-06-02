using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Chicken;

public class InsideBuildingController : MonoBehaviour
{
    public List<GameObject> Objectsinside;
    public List<GameObject> ObjectsOutside;

    private bool inside = false;
    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Chicken>())
        {
            ActiveInside(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Chicken>())
        {
            ActiveInside(false);
        }
    }
    private void ActiveInside(bool val)
    {
        if (inside == val) return;
        else inside = val;

        foreach (GameObject gO in Objectsinside)
        {
            gO.SetActive(val);
        }
        foreach (GameObject gO in ObjectsOutside)
        {
            gO.SetActive(!val);
        }
    }
}
