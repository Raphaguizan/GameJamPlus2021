using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveIfHasSave : MonoBehaviour
{
    [SerializeField]
    private bool _active = false;
    private void Awake()
    {
        if (PlayerPrefs.HasKey("Scapes"))
        {
            gameObject.SetActive(_active);
        }
        else
        {
            gameObject.SetActive(!_active);
        }
    }
}
