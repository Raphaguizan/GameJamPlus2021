using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class VersionUI : MonoBehaviour
{
    void Start()
    {
        GetComponent<TextMeshProUGUI>().text = Application.version;
    }
}
