using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffIfHasSave : MonoBehaviour
{
    private void Awake()
    {
        if (PlayerPrefs.HasKey("Scapes"))
        {
            gameObject.SetActive(false);
        }
    }
}
