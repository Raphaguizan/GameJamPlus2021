using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsideBuildingController : MonoBehaviour
{
    public List<GameObject> Objectsinside;
    public List<GameObject> ObjectsOutside;

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Chicken>())
        {
            foreach(GameObject gO in Objectsinside)
            {
                gO.SetActive(true);
            }
            foreach (GameObject gO in ObjectsOutside)
            {
                gO.SetActive(false);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Chicken>())
        {
            foreach (GameObject gO in Objectsinside)
            {
                gO.SetActive(false);
            }
            foreach (GameObject gO in ObjectsOutside)
            {
                gO.SetActive(true);
            }
        }
    }
}
