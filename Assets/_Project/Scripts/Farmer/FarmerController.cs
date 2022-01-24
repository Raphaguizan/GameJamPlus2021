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
    private int pathIndexCtrl = 1;
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
            Transform p = farmerPoints.GetChild(i);
            points.Add(p);
            p.gameObject.SetActive(false);
        }
        points[0].gameObject.SetActive(true);
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
            if(point.action == FarmerActions.WC)
            {
                NextPoint();
                StartCoroutine(MakeAction(FarmerActions.WC, 10f, "search"));
            }
            else
            {
                NextPoint();
            }
        }
    }

    IEnumerator MakeAction(FarmerActions fActions, float time, string animName)
    {
        _curretAction = FarmerActions.WC;
        MoveToggle("stop");
        anim.SetBool(animName, true);

        yield return new WaitForSeconds(time);

        anim.SetBool(animName, false);
        MoveToggle("walk");
        _curretAction = FarmerActions.NONE;
    }

    private void NextPoint()
    {
        if (pathIndex + pathIndexCtrl >= points.Count || pathIndex + pathIndexCtrl < 0)
        {
            pathIndexCtrl *= -1;
        }
        points[pathIndex].gameObject.SetActive(false);
        pathIndex += pathIndexCtrl;
        points[pathIndex].gameObject.SetActive(true);
    }

    public void MoveToggle(string value)
    {
        if (value.Equals("walk"))
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
