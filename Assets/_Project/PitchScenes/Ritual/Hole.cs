using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    [SerializeField] float speed;
    bool creating = false;
    float factor;
    private void OnEnable()
    {
        creating = true;
    }

    private void Update()
    {
        if (!creating) return;
        factor += (speed / 100) * Time.deltaTime;
        Color color = Color.white;
        color.a = factor;
        this.GetComponent<SpriteRenderer>().color = color;

    }
}
