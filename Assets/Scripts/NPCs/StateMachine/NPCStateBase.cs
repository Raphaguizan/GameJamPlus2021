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

    public class FarmerStateWalk : NPCStateBase
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

    public class FarmerStateWait : NPCStateBase
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
}
