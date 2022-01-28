using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Util;

namespace Game.Farmer.StateMachine
{
    public class FarmerStateMachine : Singleton<FarmerStateMachine>
    {

        #region declaration
       

        public Dictionary<FarmerActions, FarmerStateBase> dictionaryState;
        public static FarmerActions currentAction;

        private FarmerStateBase _currentState;


        #endregion

        #region states controller
        protected override void Awake()
        {
            base.Awake();
            dictionaryState = new Dictionary<FarmerActions, FarmerStateBase>();
            dictionaryState.Add(FarmerActions.WALK, new FarmerStateWalk());
            dictionaryState.Add(FarmerActions.WC, new FarmerStateWc());
            dictionaryState.Add(FarmerActions.YELL, new FarmerStateYell());
            dictionaryState.Add(FarmerActions.WELL, new FarmerStateWell());
            dictionaryState.Add(FarmerActions.FARM, new FarmerStateFarm());
            dictionaryState.Add(FarmerActions.TALK, new FarmerStateTalk());
        }

        private void SwitchState(FarmerActions state, object o = null)
        {
            if (_currentState != null) _currentState.OnStateExit();
            _currentState = dictionaryState[state];
            currentAction = state;
            _currentState.OnStateEnter(o);
        }

        private void Update()
        {
            if (_currentState != null) _currentState.OnStateStay();
        }
        #endregion

        #region Change State
        public static void Walk(FarmerController farmer)
        {
            Instance.SwitchState(FarmerActions.WALK, farmer);
        }
        public static void WC(FarmerController farmer)
        {
            Instance.SwitchState(FarmerActions.WC, farmer);
        }
        public static void Yell(FarmerController farmer)
        {
            Instance.SwitchState(FarmerActions.YELL, farmer);
        }
        public static void Well(FarmerController farmer)
        {
            Instance.SwitchState(FarmerActions.WELL, farmer);
        }
        public static void Farm(FarmerController farmer)
        {
            Instance.SwitchState(FarmerActions.FARM, farmer);
        }
        public static void Talk(FarmerController farmer)
        {
            Instance.SwitchState(FarmerActions.TALK, farmer);
        }
        #endregion
    }

}
