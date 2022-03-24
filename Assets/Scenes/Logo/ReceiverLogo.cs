using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceiverLogo : MonoBehaviour
{
    public void ChangeScene()
    {
        GameManager.Instance.MainMenu(true, 1);
    }
}
