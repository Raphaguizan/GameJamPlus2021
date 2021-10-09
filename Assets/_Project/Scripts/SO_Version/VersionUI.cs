using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VersionUI : MonoBehaviour
{
    public SO_Version version;
    public TextMeshProUGUI textMesh;
    void Start()
    {
        textMesh.text = version.value;
    }
}
