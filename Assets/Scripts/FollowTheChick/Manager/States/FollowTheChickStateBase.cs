using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.StateMachine;

namespace Game.Minigame.FollowTheChick
{
    public class FollowTheChickStateBase : StateBase
    {
        FollowTheChickManager manager;
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
        }
    }
    public class FollowTheChickStateChickRun : FollowTheChickStateBase
    {
        public override void OnStateEnter(params object[] o)
        {
            base.OnStateEnter(o);
        }
    }
    public class FollowTheChickStateKarenTurn : FollowTheChickStateBase
    {
        public override void OnStateEnter(params object[] o)
        {
            base.OnStateEnter(o);
        }
    }
    public class FollowTheChickStateLose : FollowTheChickStateBase
    {
        public override void OnStateEnter(params object[] o)
        {
            base.OnStateEnter(o);
        }
    }
    public class FollowTheChickStateWin : FollowTheChickStateBase
    {
        public override void OnStateEnter(params object[] o)
        {
            base.OnStateEnter(o);
        }
    }
}