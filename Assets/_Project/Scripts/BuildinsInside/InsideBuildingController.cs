using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsideBuildingController : MonoBehaviour
{
    public List<GameObject> ObjectsToToggle;

    private bool _controller = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Chicken>() && _controller)
        {
            foreach(GameObject gO in ObjectsToToggle)
            {
                gO.SetActive(!gO.activeInHierarchy);
            }
            _controller = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        _controller = true;
    }
}
