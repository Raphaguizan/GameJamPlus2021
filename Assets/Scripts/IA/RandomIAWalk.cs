using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RandomIAWalk : MonoBehaviour
{
    public float moveRadius;
    public NavMeshAgent NavAgent;
    public float targetRadius;
    public Vector2 randomWaitTime;
    [Space]
    public Animator anim;

    private bool _isWalking = false;
    Vector3 randomposition;
    float initialSpeed;
    private void Start()
    {
        randomposition = ChoosePoint();
        initialSpeed = NavAgent.speed;
        StartCoroutine(RandomAnimations());
    }
    void Update()
    {
        if (NavAgent.enabled == false) return;

        if ((Vector3.Distance(NavAgent.transform.position, randomposition) <= targetRadius) && _isWalking)
        {
            NavAgent.speed = 0;
            _isWalking = false;
            StartCoroutine(WaitToWalkAgain());
        }

        if (NavAgent.SetDestination(randomposition))
        {
            if (!NavAgent.hasPath)
            {
                randomposition = ChoosePoint();
            }
        }

        WalkAnimation();
    }

    private void WalkAnimation()
    {
        if (!_isWalking)
        {
            anim.SetBool("Walk", false);
        }
        else
        {
            anim.SetBool("Walk", true);
        }
    }

    IEnumerator RandomAnimations()
    {
        while (true)
        {
            if (!_isWalking)
            {
                float _randomTime = Random.Range(randomWaitTime.x, randomWaitTime.y/2);
                yield return new WaitForSeconds(_randomTime);
                if (!_isWalking)
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
            else
            {
                yield return null;
            }
        }
    }

    private Vector3 ChoosePoint()
    {
        Vector3 position = transform.position + Random.insideUnitSphere * moveRadius;
        position.y = 100f;
        RaycastHit hit;
        if ((Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up), out hit, Mathf.Infinity)
            || Physics.Raycast(transform.position, transform.TransformDirection(-Vector3.up), out hit, Mathf.Infinity))&& hit.transform.CompareTag("ground"))
        {
            position.y = hit.point.y;
            _isWalking = true;
            return position;
        }
        return Vector3.zero;
    }

    void OnDrawGizmos()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(randomposition, targetRadius);
    }

    IEnumerator WaitToWalkAgain()
    {
        yield return new WaitForSeconds(Random.Range(randomWaitTime.x, randomWaitTime.y));
        randomposition = ChoosePoint();
        NavAgent.speed = initialSpeed;
    }
}
