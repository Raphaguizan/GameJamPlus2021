using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.StateMachine;

namespace Game.Minigame.FollowTheChick
{
    public class FollowTheChickStateBase : StateBase
    {
        protected FollowTheChickManager manager;
        public override void OnStateEnter(params object[] o)
        {
            manager = (FollowTheChickManager)o[0];
        }
    }
    public class FollowTheChickStateBegin : FollowTheChickStateBase
    {
        public override void OnStateEnter(params object[] o)
        {
            base.OnStateEnter(o);
            manager.chicken.ChangeCanMove(false);
            manager.beginCamera.SetActive(true);
            manager.chickStateMachine.Begin();

            manager.StateWait(FollowTheChickStates.CHICK_RUN , 5f);
        }
        public override void OnStateExit()
        {
            manager.chickStateMachine.Run();
            manager.beginCamera.SetActive(false);
        }
    }
    public class FollowTheChickStateChickRun : FollowTheChickStateBase
    {
        public override void OnStateEnter(params object[] o)
        {
            base.OnStateEnter(o);
            manager.runCamera.SetActive(true);
        }
        public override void OnStateExit()
        {
            manager.runCamera.SetActive(false);
        }
    }
    public class FollowTheChickStateKarenTurn : FollowTheChickStateBase
    {
        public override void OnStateEnter(params object[] o)
        {
            base.OnStateEnter(o);
            manager.chicken.ChangeCanMove(true);
        }
        public override void OnStateExit()
        {
            manager.chicken.ChangeCanMove(false);
        }
    }
    public class FollowTheChickStateLose : FollowTheChickStateBase
    {
        public override void OnStateEnter(params object[] o)
        {
            base.OnStateEnter(o);
            manager.loseCamera.SetActive(true);
            manager.ReloadScene(5f);
        }
        public override void OnStateExit()
        {
            manager.loseCamera.SetActive(false);
        }
    }
    public class FollowTheChickStateWin : FollowTheChickStateBase
    {
        public override void OnStateEnter(params object[] o)
        {
            base.OnStateEnter(o);
            manager.chicken.ChangeCanMove(true);
            manager.winCamera.SetActive(true);
            manager.FinalWallActive(false);
            manager.chickStateMachine.Win();
        }
        public override void OnStateExit()
        {
            manager.winCamera.SetActive(false);
        }
    }
}