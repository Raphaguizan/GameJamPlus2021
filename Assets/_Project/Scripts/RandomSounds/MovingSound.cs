using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingSound : MonoBehaviour
{
    public float soundDelay = 2f;
    public float cooldown = 1;

    private Rigidbody rb;
    private RandomSound randomSound;
    private float currentCooldown = 0;

    private bool _canSound = false;

    private void OnEnable()
    {
        StopAllCoroutines();
        _canSound = false;
        StartCoroutine(waitTimeToSound());
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        randomSound = GetComponent<RandomSound>();
    }

    IEnumerator waitTimeToSound()
    {
        yield return new WaitForSeconds(soundDelay);
        _canSound = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_canSound) return;
        if(rb.velocity != Vector3.zero && currentCooldown >= cooldown){
            randomSound.PlayRandom();
            currentCooldown = 0;
        }
        currentCooldown += Time.deltaTime;
    }

    void OnCollisionEnter() {
        if (!_canSound) return;
        randomSound.PlayRandom();
    }
}
