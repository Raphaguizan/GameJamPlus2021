using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.StateMachine;

namespace Game.Minigame.FollowTheChick
{
    public class FollowTheChickManager : MonoBehaviour
    {
        public FollowTheChickStateMachine stateMachine;

        private void Start()
        {
            stateMachine.Begin(this);
        }
    }
}