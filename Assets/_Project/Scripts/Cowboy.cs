using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cowboy : MonoBehaviour
{
    [SerializeField] SO_Dialog dialog;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateDialog()
    {
        DialogManager.Instance.StartDialog(dialog);
    }

}
