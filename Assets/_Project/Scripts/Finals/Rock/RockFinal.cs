using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockFinal : MonoBehaviour
{
    public ParticleSystem vfx;
    public List<GameObject> dropItens;
    public GameObject wc;
    public GameObject virtualCamera;

    public GameObject reward;

    public AudioSource rollSound;
    public AudioSource explosionSound;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("wc"))
        {
            MakeExplosion();
        }
    }


    private void MakeExplosion()
    {
        vfx.Play();
        rollSound.Stop();
        explosionSound.Play();
        if (FarmerController.TryKill(FarmerActions.WC))
        {
            var aux = Instantiate(reward);
            aux.transform.position = vfx.transform.position;
        }
        Destroy(wc, 2);
        Invoke(nameof(SpawnItens), 2f);
        Invoke(nameof(ReturnCamera), 4f);
    }

    private void ReturnCamera()
    {
        virtualCamera.SetActive(false);
    }

    private void SpawnItens()
    {
        foreach(GameObject g in dropItens)
        {
            var aux = Instantiate(g);
            aux.transform.position = vfx.transform.position;
        }
    }
}
