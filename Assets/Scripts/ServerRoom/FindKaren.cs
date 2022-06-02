using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Chicken;

public class FindKaren : MonoBehaviour
{
    [HideInInspector]
    public Chicken karen;

    private void Start()
    {
        karen = GameObject.FindObjectOfType<Chicken>();
    }

    public void ChangeKarenGraphic(bool val)
    {
        if (karen != null)
        {
            karen.ChangeCanMove(val);
            karen.ChangeGraphic(val);
        }
    }
}
