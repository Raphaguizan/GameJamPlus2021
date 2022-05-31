using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Game.Minigame.FollowTheChick
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
        [SerializeField]
        private Transform finishPos2;
        
        [Space]
        public Transform currentTarget;

        [Space, SerializeField]
        private float waitTime;

        private ChickStateMachine stateMachine;

        private void Awake()
        {
            stateMachine = GetComponent<ChickStateMachine>();
            stateMachine.RegisterController(this);
            graphic.localRotation = Quaternion.identity;
        }

        public bool GetNextPoint()
        {
            if (currentTarget == finishPos)
            {
                stateMachine.Finish();
                return false;
            }
            currentTarget = matrix.NextPathPoint();
            if(currentTarget == null)
            {
                currentTarget = finishPos;
            }
            return true;
        }

        public void MoveToFinishPoint2()
        {
            agent.SetDestination(finishPos2.position);
        }

        public void MoveChick()
        {
            if (!currentTarget) return;
            StartCoroutine(MoveControl());
        }
        IEnumerator MoveControl()
        {
            yield return new WaitForEndOfFrame();
            agent.SetDestination(currentTarget.position);
            yield return new WaitForEndOfFrame();
            while (agent.remainingDistance > agent.radius)
            {
                yield return null;
            }
            matrix.HitPoint(waitTime);
            stateMachine.Wait();
        }

        public void Wait()
        {
            StartCoroutine(WaitCoroutine());
        }
        IEnumerator WaitCoroutine()
        {
            yield return new WaitForSeconds(waitTime);
            stateMachine.Run();
        }

        public void LookAtPlayer()
        {
            graphic.LookAt(player, Vector3.up);
        }
    }
}