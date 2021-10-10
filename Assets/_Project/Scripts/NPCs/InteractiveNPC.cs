using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveNPC : MonoBehaviour
{
    [SerializeField] SO_Dialog dialog;

    public Outline outline;
    public float strenth = .8f;
    private void Start()
    {
        outline.OutlineWidth = 0f;
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
        }
    }
    public void ActivateDialog()
    {
        DialogManager.Instance.StartDialog(dialog);
    }
}
