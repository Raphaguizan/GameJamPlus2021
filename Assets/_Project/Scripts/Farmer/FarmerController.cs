using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FarmerController : MonoBehaviour
{
    public Transform farmerPoints;
    public NavMeshAgent agent;
    public Animator anim;
    [Space]
    public float chickenCooldown = 5f;

    private bool canBeHited = true;
    private float initalSpeed;
    private List<Transform> points;
    private int pathIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        points = new List<Transform>();
        initalSpeed = agent.speed;
        for (int i = 0; i < farmerPoints.childCount; i++)
        {
            points.Add(farmerPoints.GetChild(i));
        }
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(points[pathIndex].position);
    }

    private void OnTriggerEnter(Collider other)
    {
        var point = other.GetComponent<FarmerPathPoint>();
        if (point)
        {
            if(point.action == FarmerActions.NONE)
            {
                
                if(pathIndex + 1 >= points.Count)
                {
                    pathIndex = 0;
                }
                else
                {
                    pathIndex++;
                }
            }
        }
    }

    public void MoveToggle(string b)
    {
        if (b.Equals("walk"))
        {
            agent.speed = initalSpeed;
        }
        else
        {
            agent.speed = 0;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && canBeHited)
        {
            canBeHited = false;
            anim.SetTrigger("angry");
            StartCoroutine(ChickenCoolDownCount());
        }
    }

    IEnumerator ChickenCoolDownCount()
    {
        yield return new WaitForSeconds(chickenCooldown);
        canBeHited = true;
    }
}
