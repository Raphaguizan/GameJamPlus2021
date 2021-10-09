using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Chicken : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float angularSpeed;
    Animator anim;
    public bool hasCarKey;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))
        {
            float runSpeed = 2 * speed;
            transform.Translate(Vector3.forward * runSpeed * Time.deltaTime, Space.Self);
            anim.SetBool("Run", true);
        }

        else if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);
            anim.SetBool("Walk", true);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(new Vector3(0, -angularSpeed * Time.deltaTime, 0));
            anim.SetBool("Walk", true);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(new Vector3(0, angularSpeed * Time.deltaTime, 0));
            anim.SetBool("Walk", true);
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            anim.SetBool("Walk", false);
            anim.SetBool("Run", false);
        }

        if (Input.GetKeyUp(KeyCode.A))
        { 
            anim.SetBool("Walk", false);
        }

        if (Input.GetKeyUp(KeyCode.D))
        {

            anim.SetBool("Walk", false);
        }

        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            anim.SetBool("Run", false);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            anim.SetBool("Eat", true);
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            anim.SetBool("Eat", false);
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "human" && Input.GetKeyDown(KeyCode.E))
        {
            other.GetComponent<Cowboy>().ActivateDialog();
                
        }

        if(other.tag == "otherChicken" && Input.GetKeyDown(KeyCode.E))
        {

            other.GetComponent<OtherChicken>().ActivateDialog();
        }

        if(other.tag == "car" && Input.GetKeyDown(KeyCode.E) && hasCarKey)
        {
            SceneManager.LoadScene("City");
        }
    }
}
