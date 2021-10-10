using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingSound : MonoBehaviour
{
    private Rigidbody rb;
    private RandomSound randomSound;
    private float cooldown = 1;
    private float currentCooldown = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        randomSound = GetComponent<RandomSound>();
    }

    // Update is called once per frame
    void Update()
    {
        if(rb.velocity != Vector3.zero && currentCooldown >= cooldown){
            randomSound.PlayRandom();
            currentCooldown = 0;
        }
        currentCooldown += Time.deltaTime;
    }

    void OnCollisionEnter() {
        randomSound.PlayRandom();
    }
}
