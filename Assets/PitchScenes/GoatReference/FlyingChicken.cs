using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingChicken : MonoBehaviour
{
    [SerializeField] float force;
     RandomSound chickenSound;
    Rigidbody rb;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        anim = this.GetComponent<Animator>();
        anim.SetTrigger("Eat");
        chickenSound = this.transform.Find("ChickenSounds").GetComponent<RandomSound>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            rb.AddForce(Vector3.up * force);
            //     anim.SetBool("RunInPlace",true);
            anim.SetTrigger("Jump");
            rb.freezeRotation = false;
            chickenSound.PlayRandom();
        }
    }
}
