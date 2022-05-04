using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.StateMachine;

namespace Game.Minigame.FollowTheChick
{
    public class ChickStateBase : StateBase
    {
        protected ChickController chick;

        public override void OnStateEnter(params object[] o)
        {
            chick = (ChickController)o[0];
        }

        public override void OnStateStay() { }

        public override void OnStateExit() { }

    }

    public class ChickStateRun : ChickStateBase
    {

        public override void OnStateEnter(params object[] o)
        {
            base.OnStateEnter(o);
            if(chick.GetNextPoint())
                chick.MoveChick();
        }

        public override void OnStateStay() 
        {
        }

        public override void OnStateExit() 
        { 
        }

    }
    public class ChickStateWait : ChickStateBase
    {

        public override void OnStateEnter(params object[] o)
        {
            base.OnStateEnter(o);
            chick.Wait();
        }

        public override void OnStateStay() { }

        public override void OnStateExit() { }

    }
    public class ChickStateBegin : ChickStateBase
    {

        public override void OnStateEnter(params object[] o)
        {
            base.OnStateEnter(o);
        }

        public override void OnStateStay() { }

        public override void OnStateExit() { }

    }
    public class ChickStateFinish : ChickStateBase
    {

        public override void OnStateEnter(params object[] o)
        {
            base.OnStateEnter(o);
            chick.matrix.CallKarenTurn();
        }

        public override void OnStateStay() 
        {
            chick.LookAtPlayer();
        }

        public override void OnStateExit() { }

    }
    public class ChickStateWin : ChickStateBase
    {

        public override void OnStateEnter(params object[] o)
        {
            base.OnStateEnter(o);
            chick.MoveToFinishPoint2();
        }

        public override void OnStateStay() 
        {
            
        }

        public override void OnStateExit() { }

    }
}