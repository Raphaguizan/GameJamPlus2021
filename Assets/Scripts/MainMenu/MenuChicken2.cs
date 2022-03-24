using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuChicken2 : MonoBehaviour
{
    float time;
    float interval = 3;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if(time > interval)
        {
            interval = Random.Range(3f, 7f);
            time = 0;
            Animate();
        }
    }

    void Animate()
    {
        float coin = Random.Range(0f, 1f);

        if(coin > .65f)
        {
            anim.SetTrigger("Eat");
        }
        else
        {
            anim.SetTrigger("TurnHead");
        }
    }
}
