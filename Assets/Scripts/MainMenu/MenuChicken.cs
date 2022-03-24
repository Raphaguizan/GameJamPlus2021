using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuChicken : MonoBehaviour
{
    [SerializeField] float angularSpeed;
    Transform pivot;
    // Start is called before the first frame update
    void Start()
    {
        pivot = transform.parent;
        this.GetComponent<Animator>().SetBool("Run",true);
    }

    // Update is called once per frame
    void Update()
    {
        pivot.Rotate(new Vector3(0, angularSpeed * Time.deltaTime, 0));
    }
}
