using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.StateMachine;

namespace Game.Minigame.FollowTheChick
{
    public class ChickStateMachine : StateMachineBase<ChickStateEnum>
    {
        private ChickController controller;
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
        public void RegisterController(ChickController ctrl)
        {
            controller = ctrl;
        }

        public void Run()
        {
            if (!controller) return;
            SwitchState(ChickStateEnum.RUN, controller);
        }
        public void Wait()
        {
            if (!controller) return;
            SwitchState(ChickStateEnum.WAIT, controller);
        }
        public void Begin()
        {
            if (!controller) return;
            SwitchState(ChickStateEnum.BEGIN, controller);
        }
        public void Finish()
        {
            if (!controller) return;
            SwitchState(ChickStateEnum.FINISH, controller);
        }
    }
}