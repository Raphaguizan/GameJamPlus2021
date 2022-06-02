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
    private void ChangeParan(bool val)
    {
        animator.SetBool(ParamName, val);
    }

    public void Close()
    {
        ChangeParan(false);
    }

    public void Open()
    {
        ChangeParan(true);
    }
}
