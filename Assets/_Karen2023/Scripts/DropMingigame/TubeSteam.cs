using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubeSteam : MonoBehaviour
{
    [SerializeField] GameObject explosion;
    [SerializeField] GameObject steam;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Activate()
    {
        explosion.SetActive(true);



        ParticleSystem ps = steam.GetComponent<ParticleSystem>();
        ParticleSystemRenderer psr = ps.GetComponent<ParticleSystemRenderer>();
        psr.material.SetColor("_MainColor", TubeManager.Instance.GetRandomColor());
        steam.SetActive(true);
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    Debug.Log(collision.gameObject.name);
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        Activate();
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger" + other.gameObject.name);
        if (other.gameObject.tag == "Player")
        {
            Activate();
        }
    }

}
