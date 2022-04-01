using Game.NPC.StateMachine;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

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
        [Space]
        public Animator anim;

        Vector3 randomposition;
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

            if ((Vector3.Distance(NavAgent.transform.position, randomposition) <= targetRadius))
            {
                stateMachine.Wait(this);
            }
        }

        public void Move()
        {
            if (NavAgent.enabled == false) return;

            if (!NavAgent.SetDestination(randomposition) || !NavAgent.hasPath)
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

        public void ChoosePoint()
        {
            Vector3 position = transform.position + Random.insideUnitSphere * moveRadius;
            position.y = 100f;
            RaycastHit hit;
            if ((Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up), out hit, Mathf.Infinity)
                || Physics.Raycast(transform.position, transform.TransformDirection(-Vector3.up), out hit, Mathf.Infinity)) && hit.transform.CompareTag("ground"))
            {
                position.y = hit.point.y;

                randomposition = position;
                return;
            }
            randomposition = Vector3.zero;
        }

        void OnDrawGizmos()
        {
            if (!drawDebugPosition) return;
            // Draw a yellow sphere at the transform's position
            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(randomposition, targetRadius);
        }

        public void StartWaitTime()
        {
            StartCoroutine(WaitToWalkAgain());
        }

        IEnumerator WaitToWalkAgain()
        {
            yield return new WaitForSeconds(Random.Range(randomWaitTime.x, randomWaitTime.y));
            stateMachine.Walk(this);
        }
    }
}
