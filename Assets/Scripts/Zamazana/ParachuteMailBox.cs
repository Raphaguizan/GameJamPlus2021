using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ParachuteMailBox : MonoBehaviour
{
    public ParachuteMail giver;
    public GameObject box;
    public UnityEvent onReceiveBoxCallback;

    private void Awake()
    {
        box.gameObject.SetActive(false);
        giver.ParachuteGiveCallBack += Active;
    }

    private void Active()
    {
        if(box) box.gameObject.SetActive(true);
        onReceiveBoxCallback.Invoke();
    }

    private void OnDisable()
    {
        giver.ParachuteGiveCallBack -= Active;
    }
}
