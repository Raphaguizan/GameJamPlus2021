using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Item;
using Game.Chicken;

public class CollectItemBase : MonoBehaviour
{
    public ItemBase item;
    public Outline outline;
    public float timeToDestroy = 0f;

    [Space, SerializeField]
    private GameObject art;

    [Space, Header("Effects"), SerializeField]
    private ParticleSystem particles;
    [SerializeField]
    private AudioSource sound;

    private bool collected = false;

    private float outline_initial_size;
    private void Start()
    {
        outline_initial_size = outline.OutlineWidth;
        outline.OutlineWidth = 0f;
        if(art)art.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        var player = other.gameObject.GetComponent<Chicken>();
        if (player && other.CompareTag("Player"))
        {
            outline.OutlineWidth = outline_initial_size;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        var player = other.gameObject.GetComponent<Chicken>();
        if (player && other.CompareTag("Player"))
        {
            outline.OutlineWidth = 0f;
        }
    }

    public virtual void Collect()
    {
        if (collected) return;

        if (art) art.SetActive(false);
        collected = true;
        outline.enabled = false;

        if (particles != null)particles.Play();
        if(sound != null)sound.Play();

        Destroy(gameObject, timeToDestroy);
        OnCollet();
    }


    protected virtual void OnCollet()
    {
        ChickenBag.Instance.AddItem(item);
    }
}
