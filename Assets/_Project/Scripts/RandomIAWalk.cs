using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RandomIAWalk : MonoBehaviour
{
    public float moveRadius;
    public NavMeshAgent NavAgent;
    public float targetHeigth;
    public Vector2 randomWaitTime;
    [Space]
    public Animator anim;

    Vector3 randomposition;
    float initialSpeed;
    private void Start()
    {
        ChoosePoint();
        initialSpeed = NavAgent.speed;
    }
    void Update()
    {
        NavAgent.SetDestination(randomposition);
        if(Vector3.Distance(NavAgent.transform.position, randomposition) < targetHeigth)
        {
            NavAgent.speed = 0;
            StartCoroutine(WaitToWalkAgain());
        }
        if(NavAgent.speed == 0)
        {
            anim.SetBool("Walk", false);
            StartCoroutine(RandomAnimations());
        }
        else
        {
            anim.SetBool("Walk", true);
        }
    }

    IEnumerator RandomAnimations()
    {
        while (!anim.GetBool("walk"))
        {
            float _randomTime = Random.Range(4, 20);
            yield return new WaitForSeconds(_randomTime);
            if (!anim.GetBool("walk"))
            {
                float randomaux = Random.value;
                if (randomaux >= 0.5f)
                {
                    anim.SetTrigger("Eat");
                }
                else
                {
                    anim.SetTrigger("TurnHead");
                }
            }

        }
    }

    private void ChoosePoint()
    {
        randomposition = Random.insideUnitSphere * moveRadius;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up), out hit, Mathf.Infinity)
            || Physics.Raycast(transform.position, transform.TransformDirection(-Vector3.up), out hit, Mathf.Infinity))
        {
            randomposition.y = hit.transform.position.y + targetHeigth;
        }
    }

    IEnumerator WaitToWalkAgain()
    {
        yield return new WaitForSeconds(Random.Range(randomWaitTime.x, randomWaitTime.y));
        ChoosePoint();
        NavAgent.speed = initialSpeed;
    }
}
