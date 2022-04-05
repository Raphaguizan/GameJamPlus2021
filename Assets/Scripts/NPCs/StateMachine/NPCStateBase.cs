using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.NPC.StateMachine
{
    public class NPCStateBase
    {
        protected RandomIAWalk myIA;
        public virtual void OnStateEnter(RandomIAWalk o)
        {
            if (o == null) return;
            myIA = o;
        }
        public virtual void OnStateStay()
        {
            //Debug.Log("Est� no estado");
        }
        public virtual void OnStateExit()
        {
            //Debug.Log("Saiu no estado");
        }
    }

    public class NPCStateWalk : NPCStateBase
    {
        public override void OnStateEnter(RandomIAWalk o)
        {
            base.OnStateEnter(o);
            myIA.ChoosePoint();
            myIA.ToggleMove(true);
        }
        public override void OnStateStay()
        {
            myIA.Move();
            myIA.VerifyGoal();
        }
        public override void OnStateExit()
        {
            myIA.ToggleMove(false);
        }
    }

    public class NPCStateWait : NPCStateBase
    {
        public override void OnStateEnter(RandomIAWalk o)
        {
            base.OnStateEnter(o);
            myIA.StartWaitTime();
        }
        public override void OnStateStay()
        {
            //Debug.Log("Est� no estado");
        }
        public override void OnStateExit()
        {
            //Debug.Log("Saiu no estado");
        }
    }

    public class NPCStateFollow : NPCStateBase
    {
        public override void OnStateEnter(RandomIAWalk o)
        {
            base.OnStateEnter(o);
            myIA.ToggleMove(true);
        }
        public override void OnStateStay()
        {
            myIA.PlayerPosition(true);
            myIA.Move();
            myIA.VerifyGoal();
        }
        public override void OnStateExit()
        {
            myIA.ToggleMove(false);
        }
    }

    public class NPCStateRun : NPCStateBase
    {
        public override void OnStateEnter(RandomIAWalk o)
        {
            base.OnStateEnter(o);
            myIA.ToggleMove(true);
        }
        public override void OnStateStay()
        {
            myIA.PlayerPosition(false);
            myIA.Move();
            myIA.VerifyGoal();
        }
        public override void OnStateExit()
        {
            myIA.ToggleMove(false);
        }
    }
}
