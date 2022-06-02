using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class SleepMenuController : MonoBehaviour
{
    [SerializeField]
    private string ParamName = "Open";
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        Close();
    }
    private void ChangeParam(bool val)
    {
        animator.SetBool(ParamName, val);
    }

    public void Close()
    {
        ChangeParam(false);
    }

    public void Open()
    {
        ChangeParam(true);
    }
}
