using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Outline), typeof(Animator))]
public class Hittable : MonoBehaviour
{
    public int life = 3;

    [SerializeField]
    private Animator anim;

    [SerializeField]
    private Outline outline;

    private float outlineSize;
    private bool dead = false;

    private void Start()
    {
        anim = GetComponent<Animator>();
        outlineSize = outline.OutlineWidth;
        outline.OutlineWidth = 0f;
    }

    public void TakeHit()
    {
        if (dead) return;
        life--;

        if(anim) anim.SetTrigger("Hit");

        if (life <= 0) Die();
    }

    private void Die()
    {
        dead = true;

        if (anim) anim.SetTrigger("Die");

       Destroy(this.gameObject, 2f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Chicken>())
        {
            outline.OutlineWidth = outlineSize;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Chicken>())
        {
            outline.OutlineWidth = 0f;
        }
    }
}
