using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Game.MiniGame.FollowTherChick
{
    [RequireComponent(typeof(ChickStateMachine))]
    public class ChickController : MonoBehaviour
    {
        public MatrixController matrix;
        public NavMeshAgent agent;
        public Transform graphic;
        public Transform player;

        [SerializeField]
        private Transform finishPos;
        
        [Space]
        public Transform currentTarget;

        [Space, SerializeField]
        private float waitTime;

        private ChickStateMachine stateMachine;

        private void Awake()
        {
            stateMachine = GetComponent<ChickStateMachine>();
            graphic.localRotation = Quaternion.identity;
        }

        private void Start()
        {
            stateMachine.Begin(this);
        }

        public void GetNextPoint()
        {
            if (currentTarget == finishPos)
            {
                stateMachine.Finish(this);
            }
            currentTarget = matrix.NextPathPoint();
            if(currentTarget == null)
            {
                currentTarget = finishPos;
            }
        }

        public void MoveChick()
        {
            if (!currentTarget) return;

            agent.SetDestination(currentTarget.position);

            if (agent.remainingDistance <= agent.radius)
            {
                stateMachine.Wait(this);
            }
        }

        public void Wait()
        {
            StartCoroutine(WaitCoroutine());
        }
        IEnumerator WaitCoroutine()
        {
            yield return new WaitForSeconds(waitTime);
            stateMachine.Run(this);
        }

        public void LookAtPlayer()
        {
            graphic.LookAt(player, Vector3.up);
        }

        // provisório
        public void WaitBegin()
        {
            StartCoroutine(WaitBeginCoroutine());
        }
        IEnumerator WaitBeginCoroutine()
        {
            yield return new WaitForSeconds(waitTime);
            stateMachine.Run(this);
        }
    }
}