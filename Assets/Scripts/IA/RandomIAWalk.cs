using Game.NPC.StateMachine;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using NaughtyAttributes;

namespace Game.NPC
{
    public class RandomIAWalk : MonoBehaviour
    {
        public NPCStateMachine stateMachine;
        public NavMeshAgent NavAgent;

        [Header("Target Params")]
        public bool drawDebugPosition = false;
        public float moveRadius;
        public float targetRadius;
        public Vector2 randomWaitTime;
        [Header("Follow Params")]
        public Transform playerTrans;
        public float distaceOfTarget = 1f;
        [Space]
        public Animator anim;

        Vector3 targetPosition;
        float initialSpeed;
        private void Start()
        {
            initialSpeed = NavAgent.speed;
            StartCoroutine(RandomAnimations());
            stateMachine.Walk(this);
        }

        public void VerifyGoal()
        {
            if (NavAgent.enabled == false) return;

            if ((Vector3.Distance(NavAgent.transform.position, targetPosition) <= targetRadius + distaceOfTarget))
            {
                if(stateMachine.currentAction == NPCActions.FOLLOW)
                    GetTarget();

                stateMachine.Wait(this);
            }
        }

        public void Move()
        {
            if (NavAgent.enabled == false) return;

            if (!NavAgent.SetDestination(targetPosition) || !NavAgent.hasPath)
            {
                stateMachine.Walk(this);
            }
        }

        public void ToggleMove(bool isOn)
        {
            if (NavAgent.enabled == false) return;
            if (isOn)
                NavAgent.speed = initialSpeed;
            else
                NavAgent.speed = 0;
            anim.SetBool("Walk", isOn);
        }

        IEnumerator RandomAnimations()
        {
            while (true)
            {
                if (stateMachine.currentAction == NPCActions.WAIT)
                {
                    float _randomTime = Random.Range(randomWaitTime.x, randomWaitTime.y / 2);
                    yield return new WaitForSeconds(_randomTime);
                    if (stateMachine.currentAction == NPCActions.WAIT)
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

        public void PlayerPosition(bool direction)
        {
            if (direction)
            {
                targetPosition = playerTrans.position;
            }
            else
            {
                targetPosition = AdjustToFloor(transform.position + (transform.position - playerTrans.position).normalized);
            }
        }

        public void GetTarget()
        {
            Debug.Log("Pegou o player");
        }

        public void ChoosePoint()
        {
            Vector3 position = transform.position + Random.insideUnitSphere * moveRadius;
            targetPosition = AdjustToFloor(position);
        }

        private Vector3 AdjustToFloor(Vector3 point)
        {
            point.y = 100;
            RaycastHit hit;
            if ((Physics.Raycast(point, transform.TransformDirection(Vector3.up), out hit, Mathf.Infinity)
                || Physics.Raycast(point, transform.TransformDirection(-Vector3.up), out hit, Mathf.Infinity)) && hit.transform.CompareTag("ground"))
            {
                point.y = hit.point.y;
            }
            return point;
        }

        void OnDrawGizmos()
        {
            if (!drawDebugPosition) return;
            // Draw a yellow sphere at the transform's position
            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(targetPosition, targetRadius);
        }

        public void StartWaitTime()
        {
            StartCoroutine(WaitToWalkAgain());
        }

        IEnumerator WaitToWalkAgain()
        {
            yield return new WaitForSeconds(Random.Range(randomWaitTime.x, randomWaitTime.y));
            if(stateMachine.currentAction == NPCActions.WAIT)
                stateMachine.Walk(this);
        }

        [Button]
        public void ChangeStateToFollow()
        {
            stateMachine.Follow(this);
        }
        [Button]
        public void ChangeStateToRun()
        {
            stateMachine.Run(this);
        }
    }
}
