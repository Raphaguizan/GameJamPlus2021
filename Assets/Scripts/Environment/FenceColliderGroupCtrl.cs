using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenceColliderGroupCtrl : MonoBehaviour
{
    [SerializeField]
    private List<FenceColliderCtrl> group;

    public void DisableHighCollider()
    {
        ChangeColliders(false);
    }

    public void ChangeColliders(bool isHigh)
    {
        foreach (FenceColliderCtrl ctrl in group)
        {
            ctrl.ChangeColliders(isHigh);
        }
    }
}
