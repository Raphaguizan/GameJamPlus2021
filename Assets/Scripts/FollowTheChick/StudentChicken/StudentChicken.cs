using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Game.Minigame.FollowTheChick
{
    [RequireComponent(typeof(NavMeshObstacle))]
    public class StudentChicken : MonoBehaviour
    {
        [SerializeField]
        private string animationString = "Act";

        [SerializeField]
        private NavMeshObstacle navMeshObstacle;
        [SerializeField]
        private Animator animator;
        private void OnValidate()
        {
            if(navMeshObstacle == null)navMeshObstacle = GetComponent<NavMeshObstacle>();
            if(animator == null)animator = GetComponent<Animator>();
        }

        public StudentChicken SelectChicken()
        {
            navMeshObstacle.enabled = false;
            return this;
        }

        public void MakeAnimation(float timeDelay)
        {
            if (animator) animator.SetTrigger(animationString);
            StartCoroutine(NavMeshDelay(true, timeDelay + 1f));
        }

        IEnumerator NavMeshDelay(bool val, float time = 0)
        {
            yield return new WaitForSeconds(time);
            navMeshObstacle.enabled = val;
        }
    }
}