using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Game.Chicken;

public class FallFinal : MonoBehaviour
{
    public UnityEvent fall;
    public UnityEvent beach;
    private void OnTriggerEnter(Collider other)
    {
        Chicken chicken = other.GetComponent<Chicken>();
        if (chicken)
        {
            if (chicken.powerUps.parachuteEnabled)
            {
                beach.Invoke();
            }
            else
            {
                fall.Invoke();
            }
        }
    }
}
