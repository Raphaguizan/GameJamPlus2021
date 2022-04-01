using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Farmer.StateMachine
{
    public class FarmerStateBase 
    {
        protected FarmerController myFarmer;
        public virtual void OnStateEnter(FarmerController o)
        {
            //Debug.Log("Entrou no estado");
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

    public class FarmerStateWalk : FarmerStateBase
    {
        public override void OnStateEnter(FarmerController o)
        {
            if (o == null) return;
            myFarmer = o;
            o.NextPoint();
            myFarmer.MoveToggle(true);
        }
        public override void OnStateStay()
        {
            if (myFarmer.agent.enabled == false) return;
            myFarmer.agent.SetDestination(myFarmer.points[myFarmer.pathIndex].position);
        }
        public override void OnStateExit()
        {
            myFarmer.MoveToggle(false);
        }
    }
    public class FarmerStateWc : FarmerStateBase
    {
        public override void OnStateEnter(FarmerController o)
        {
            myFarmer = o;
            myFarmer.anim.SetBool("search", true);
            FarmerStateMachine.ActiveAutoStateChange(10f, FarmerActions.WALK, myFarmer);
        }
        public override void OnStateExit()
        {
            myFarmer.anim.SetBool("search", false);
        }
    }
    public class FarmerStateWell : FarmerStateBase
    {
        public override void OnStateEnter(FarmerController o)
        {
            myFarmer = o;
            myFarmer.anim.SetBool("search", true);
            myFarmer.ToggleItemDrop(true);
            FarmerStateMachine.ActiveAutoStateChange(10f, FarmerActions.WALK, myFarmer);
        }
        public override void OnStateExit()
        {
            myFarmer.anim.SetBool("search", false);
            myFarmer.ToggleItemDrop(false);
        }
    }
    public class FarmerStateFarm : FarmerStateBase
    {
        public override void OnStateEnter(FarmerController o)
        {
            myFarmer = o;
            myFarmer.anim.SetBool("search", true);
            FarmerStateMachine.ActiveAutoStateChange(10f, FarmerActions.WALK, myFarmer);
        }
        public override void OnStateExit()
        {
            myFarmer.anim.SetBool("search", false);
        }
    }
    public class FarmerStateTalk : FarmerStateBase
    {
        public override void OnStateEnter(FarmerController o)
        {
            //Debug.Log("Entrou no estado");
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
    public class FarmerStateDie : FarmerStateBase
    {
        public override void OnStateEnter(FarmerController o)
        {
            o.anim.SetTrigger("die");
            o.ChangeCanbiHited(false);
            o.agent.enabled = false;
            var collider = o.GetComponent<Collider>();
            if (collider) collider.enabled = false;
        }
    }
}

