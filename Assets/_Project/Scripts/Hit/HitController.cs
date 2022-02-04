using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitController : MonoBehaviour
{
    public float rbHitForce; 

    private GameObject _currentTarget = null;
    private Rigidbody objRB = null;
    private Hittable objHitble = null;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Hittable>() || other.GetComponent<Rigidbody>())
        {
            _currentTarget = other.gameObject;
            objHitble = other.GetComponent<Hittable>();
            objRB = other.GetComponent<Rigidbody>();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (_currentTarget == null) return;
        if (other.gameObject.Equals(_currentTarget))
        {
            _currentTarget = null;
            objHitble = null;
            objRB = null;
        }
    }

    public void Hit()
    {
        if (!_currentTarget) return;

        if (objHitble) objHitble.TakeHit();
        else if(objRB) objRB.AddForce(Vector3.up * rbHitForce, ForceMode.Impulse);
    }
}
