using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Game.Util;
using Game.Farmer.StateMachine;

namespace Game.Farmer
{
    public class FarmerController : Singleton<FarmerController>
    {
        public Transform farmerPoints;
        public NavMeshAgent agent;
        public Animator anim;
        [Space]
        public float chickenCooldown = 5f;
        [Space]
        public DropItem itemDrop;

        [HideInInspector]
        public int pathIndex = 0;
        [HideInInspector]
        public List<Transform> points;

        private bool canBeHited = true;
        private float initalSpeed;
        private int pathIndexCtrl = 1;
        private RandomSound rantSound;
        
        // Start is called before the first frame update
        void Start()
        {
            points = new List<Transform>();
            initalSpeed = agent.speed;
            for (int i = 0; i < farmerPoints.childCount; i++)
            {
                Transform p = farmerPoints.GetChild(i);
                points.Add(p);
                p.gameObject.SetActive(false);
            }
            points[0].gameObject.SetActive(true);
            rantSound = GetComponent<RandomSound>();
            ToggleItemDrop(false);
            FarmerStateMachine.Walk(this);
        }


        private void OnTriggerEnter(Collider other)
        {
            var point = other.GetComponent<FarmerPathPoint>();
            if (point && other.CompareTag("PathPoint"))
            {
                FarmerStateMachine.Instance.SwitchState(point.action, this);
            }
        }

        public void NextPoint()
        {
            if (pathIndex + pathIndexCtrl >= points.Count || pathIndex + pathIndexCtrl < 0)
            {
                pathIndexCtrl *= -1;
            }
            points[pathIndex].gameObject.SetActive(false);
            pathIndex += pathIndexCtrl;
            points[pathIndex].gameObject.SetActive(true);
        }

        public void ToggleItemDrop(bool val)
        {
            itemDrop.enabled = val;
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
        public void MoveToggle(bool value)
        {
            if (value)
                MoveToggle("walk");
            else
                MoveToggle("stop");
        }

        public void ChangeCanbiHited(bool val)
        {
            canBeHited = val;
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
            if (action == FarmerStateMachine.currentAction)
            {
                Instance.Kill();
                return true;
            }
            return false;
        }

        public void Kill()
        {
            FarmerStateMachine.Die(this);
        }
    }
}