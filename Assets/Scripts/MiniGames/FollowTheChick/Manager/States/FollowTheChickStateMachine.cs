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
        private FollowTheChickManager manager;
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

        public void RegisterManager(FollowTheChickManager manag)
        {
            manager = manag;
        }

        public void Begin()
        {
            if (!manager) return;
            SwitchState(FollowTheChickStates.BEGIN, manager);
        }
        public void ChickRun()
        {
            if (!manager) return;
            SwitchState(FollowTheChickStates.CHICK_RUN, manager);
        }
        public void KarenTurn()
        {
            if (!manager) return;
            SwitchState(FollowTheChickStates.KAREN_TURN, manager);
        }
        public void Lose()
        {
            if (!manager) return;
            SwitchState(FollowTheChickStates.LOSE, manager);
        }
        public void Win()
        {
            if (!manager) return;
            SwitchState(FollowTheChickStates.WIN, manager);
        }
    }
}