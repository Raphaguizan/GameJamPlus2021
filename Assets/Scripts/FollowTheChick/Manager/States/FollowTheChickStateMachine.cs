using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.StateMachine;

namespace Game.Minigame.FollowTheChick
{
    public enum FollowTheChickStates
    {
        BEGIN,
        CHICK_RUN,
        KAREN_TURN,
        LOSE,
        WIN
    }
    public class FollowTheChickStateMachine : StateMachineBase<FollowTheChickStates>
    {
        private void Awake()
        {
            Initialize();
        }
        protected override void InitialRegister()
        {
            RegisterState(FollowTheChickStates.BEGIN, new FollowTheChickStateBegin());
            RegisterState(FollowTheChickStates.CHICK_RUN, new FollowTheChickStateChickRun());
            RegisterState(FollowTheChickStates.KAREN_TURN, new FollowTheChickStateKarenTurn());
            RegisterState(FollowTheChickStates.LOSE, new FollowTheChickStateLose());
            RegisterState(FollowTheChickStates.WIN, new FollowTheChickStateWin());
        }

        public void Begin(FollowTheChickManager manager)
        {
            SwitchState(FollowTheChickStates.BEGIN, manager);
        }
        public void ChickRun(FollowTheChickManager manager)
        {
            SwitchState(FollowTheChickStates.CHICK_RUN, manager);
        }
        public void KarenTurn(FollowTheChickManager manager)
        {
            SwitchState(FollowTheChickStates.KAREN_TURN, manager);
        }
        public void Lose(FollowTheChickManager manager)
        {
            SwitchState(FollowTheChickStates.LOSE, manager);
        }
        public void Win(FollowTheChickManager manager)
        {
            SwitchState(FollowTheChickStates.WIN, manager);
        }
    }
}