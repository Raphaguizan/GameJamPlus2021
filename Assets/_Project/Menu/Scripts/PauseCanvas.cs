using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseCanvas : MonoBehaviour
{
    [SerializeField] Animator chickenMenu;

    public void CloseMenu()
    {
        this.GetComponent<Animator>().SetTrigger("Close");
       
    }

    public void CallChicken()
    {
        chickenMenu.SetBool("Hit", true);
    }

    public void ChickenRuning()
    {
        chickenMenu.SetBool("Hit", false);
    }
    public void RotateChicken()
    {
        Quaternion rot = chickenMenu.transform.rotation;
        rot.y *= -1;
        chickenMenu.transform.rotation = rot;
    }
    public void Deactivate()
    {
        ChickenRuning();
        this.gameObject.SetActive(false);
    }

         
}
