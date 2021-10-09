using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherChicken : MonoBehaviour
{
    [SerializeField] SO_Dialog dialog;
    public void ActivateDialog()
    {
        DialogManager.Instance.StartDialog(dialog);
    }

}
