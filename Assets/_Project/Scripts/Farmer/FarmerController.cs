using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Game.Util;

public class FarmerController : Singleton<FarmerController>
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
    private RandomSound rantSound;
    private FarmerActions _curretAction;
    // Start is called before the first frame update
    void Start()
    {
        points = new List<Transform>();
        _curretAction = FarmerActions.NONE;
        initalSpeed = agent.speed;
        for (int i = 0; i < farmerPoints.childCount; i++)
        {
            points.Add(farmerPoints.GetChild(i));
        }
        rantSound = GetComponent<RandomSound>();
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.enabled == false) return;
        agent.SetDestination(points[pathIndex].position);
    }

    private void OnTriggerEnter(Collider other)
    {
        var point = other.GetComponent<FarmerPathPoint>();
        if (point)
        {
            if(point.action == FarmerActions.NONE)
            {
                NextPoint();
            }

            if(point.action == FarmerActions.WC)
            {
                _curretAction = FarmerActions.WC;
                MoveToggle("stop");
                anim.SetBool("search", true);
                NextPoint();
                StartCoroutine(WaitSomeTime(10f, "search"));
            }
        }
    }

    IEnumerator WaitSomeTime(float time, string animName)
    {
        yield return new WaitForSeconds(time);
        anim.SetBool(animName, false);
        MoveToggle("walk");
        _curretAction = FarmerActions.NONE;
    }



    private void NextPoint()
    {
        if (pathIndex + 1 >= points.Count)
        {
            pathIndex = 0;
        }
        else
        {
            pathIndex++;
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
            rantSound.PlayRandom();
            anim.SetTrigger("angry");
            StartCoroutine(ChickenCoolDownCount());
        }
    }

    IEnumerator ChickenCoolDownCount()
    {
        yield return new WaitForSeconds(chickenCooldown);
        canBeHited = true;
    }

    public static bool TryKill(FarmerActions action)
    {
        if(action == Instance._curretAction)
        {
            Instance.Kill();
            return true;
        }
        return false;
    }

    public void Kill()
    {
        anim.SetTrigger("die");
        canBeHited = false;
        agent.enabled = false;
        var collider = GetComponent<Collider>();
        if (collider) collider.enabled = false;
    }
}
