using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenceColliderCtrl : MonoBehaviour
{
    [SerializeField]
    private GameObject highCollider;
    [SerializeField]
    private GameObject lowCollider;
    // Start is called before the first frame update
    void Start()
    {
        ChangeColliders(true);
    }
    
    public void DisableHighCollider()
    {
        ChangeColliders(false);
    }

    public void ChangeColliders(bool isHigh)
    {
        highCollider.SetActive(isHigh);
        lowCollider.SetActive(!isHigh);
    }
}
