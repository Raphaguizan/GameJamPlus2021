using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Game.Chicken;

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

        #region Chick
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
        #endregion

        #region Karen Interactions

        void OnTriggerEnter(Collider other)
        {
            Debug.Log(other.name);
            if (other.gameObject.GetComponent<Chicken.Chicken>())
            {
                MakeAnimation();
            }
        }

        public void MakeAnimation()
        {
            if (animator) animator.SetTrigger(animationString);
        }
        #endregion
    }
}