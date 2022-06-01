using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseCanvas : MonoBehaviour
{
  //  [SerializeField] Animator chickenMenu;
    bool controlsImageIsOn = false;

    public void CloseMenu()
    {
        if(controlsImageIsOn)
        {
            CloseControls();
            
        }
        this.GetComponent<Animator>().SetTrigger("Close");
       
    }

    public void OpenControls()
    {
        controlsImageIsOn = true;
        this.GetComponent<Animator>().SetTrigger("OpenControls");
    }

    public void CloseControls()
    {
        controlsImageIsOn = false;
        this.GetComponent<Animator>().SetTrigger("CloseControls");
    }
    //public void CallChicken()
    //{
    //    chickenMenu.SetBool("Hit", true);
    //}

    //public void ChickenRuning()
    //{
    //    chickenMenu.SetBool("Hit", false);
    //}
    //public void RotateChicken()
    //{
    //    Quaternion rot = chickenMenu.transform.rotation;
    //    rot.y *= -1;
    //    chickenMenu.transform.rotation = rot;
    //}
    public void Deactivate()
    {
       // ChickenRuning();
        this.gameObject.SetActive(false);
    }

         
}
