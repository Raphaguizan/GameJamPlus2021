using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitController : MonoBehaviour
{
    private Hittable _currentTarget;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Hittable>())
        {
            _currentTarget = other.GetComponent<Hittable>();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (_currentTarget == null) return;
        if (other.GetComponent<Hittable>().Equals(_currentTarget))
        {
            _currentTarget = null;
        }
    }

    public void Hit()
    {
        if (!_currentTarget) return;
        _currentTarget.TakeHit();
    }
}
