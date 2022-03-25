using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Chicken.foot
{
    public class CollisionFoot : MonoBehaviour
    {
        public Chicken galinha;
        public float heightLimit;

        private void Update()
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up), out hit, Mathf.Infinity))
            {
                if (hit.distance < heightLimit)
                {
                    galinha.ChangeIsJump(false);
                }
                else
                {
                    galinha.ChangeIsJump(true);
                }
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.up) * heightLimit, Color.red);
            }
        }
    }
}

