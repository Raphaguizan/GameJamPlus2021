using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseChicken : MonoBehaviour
{
    [SerializeField] Animator menuAnim;
   public void CloseMenu()
    {
        menuAnim.SetBool("close", true);
    }
}
