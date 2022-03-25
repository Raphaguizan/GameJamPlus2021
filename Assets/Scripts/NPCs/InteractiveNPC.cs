using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Chicken;

public class InteractiveNPC : MonoBehaviour
{
    [SerializeField] SO_Dialog dialog;

    public Outline outline;
    public float strenth = .8f;
    private void Start()
    {
        outline.OutlineWidth = 0f;
        dialog.hasItem = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        var player = other.gameObject.GetComponent<Chicken>();
        if (player)
        {
            outline.OutlineWidth = strenth;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        var player = other.gameObject.GetComponent<Chicken>();
        if (player)
        {
            outline.OutlineWidth = 0f;
            DialogManager.Instance.CloseDialog();
        }
    }
    public void ActivateDialog()
    {
        DialogManager.Instance.StartDialog(dialog);
    }
}
