using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionFoot : MonoBehaviour
{
    public Chicken galinha;

    private void OnTriggerStay(Collider other)
    {
        galinha.ChangeIsJump(false);
    }

    private void OnTriggerExit(Collider other)
    {
        galinha.ChangeIsJump(true);
    }
}
