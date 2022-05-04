using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.StateMachine;

namespace Game.Minigame.FollowTheChick
{
    public class ChickStateMachine : StateMachineBase<ChickStateEnum>
    {
        
        private void Awake()
        {
            Initialize();
        }
        protected override void InitialRegister()
        {
            RegisterState(ChickStateEnum.RUN, new ChickStateRun());
            RegisterState(ChickStateEnum.WAIT, new ChickStateWait());
            RegisterState(ChickStateEnum.BEGIN, new ChickStateBegin());
            RegisterState(ChickStateEnum.FINISH, new ChickStateFinish());
        }

        public void Run(ChickController chick)
        {
            SwitchState(ChickStateEnum.RUN, chick);
        }
        public void Wait(ChickController chick)
        {
            SwitchState(ChickStateEnum.WAIT, chick);
        }
        public void Begin(ChickController chick)
        {
            SwitchState(ChickStateEnum.BEGIN, chick);
        }
        public void Finish(ChickController chick)
        {
            SwitchState(ChickStateEnum.FINISH, chick);
        }
    }
}