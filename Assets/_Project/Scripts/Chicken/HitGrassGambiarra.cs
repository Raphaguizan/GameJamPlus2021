using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitGrassGambiarra : MonoBehaviour
{
    [SerializeField] private Vector2 posAdjust;
    [SerializeField] private Transform chiken;

    // Update is called once per frame
    void Update()
    {
        // movimenta a grama no shader
        Shader.SetGlobalFloat("_obsx", chiken.position.x + posAdjust.x);
        Shader.SetGlobalFloat("_obsz", chiken.position.z + posAdjust.y);
    }
}
