using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FarmerController : MonoBehaviour
{
    public Transform farmerPoints;
    public float speed = 2;
    public NavMeshAgent agent;

    private List<Transform> points;
    private int pathIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        points = new List<Transform>();
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
}
