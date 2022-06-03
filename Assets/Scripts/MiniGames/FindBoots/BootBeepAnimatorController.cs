using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BootBeepAnimatorController : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    [SerializeField]
    private string triggerName = "Beep";

    public void BeepLight()
    {
        if (animator)
            animator.SetTrigger(triggerName);
    }
}
