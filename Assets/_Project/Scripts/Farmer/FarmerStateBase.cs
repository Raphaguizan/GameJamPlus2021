using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Farmer.StateMachine
{
    public class FarmerStateBase
    {
        public virtual void OnStateEnter(object o = null)
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
        public override void OnStateEnter(object o = null)
        {
            Debug.Log("Entrou no estado Walk");
        }
        public override void OnStateStay()
        {
            //Debug.Log("Est� no estado");
        }
        public override void OnStateExit()
        {
            Debug.Log("Saiu no estado Walk");
        }
    }
    public class FarmerStateWc : FarmerStateBase
    {
        public override void OnStateEnter(object o = null)
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
    public class FarmerStateYell : FarmerStateBase
    {
        public override void OnStateEnter(object o = null)
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
    public class FarmerStateWell : FarmerStateBase
    {
        public override void OnStateEnter(object o = null)
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
    public class FarmerStateFarm : FarmerStateBase
    {
        public override void OnStateEnter(object o = null)
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
    public class FarmerStateTalk : FarmerStateBase
    {
        public override void OnStateEnter(object o = null)
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
}

