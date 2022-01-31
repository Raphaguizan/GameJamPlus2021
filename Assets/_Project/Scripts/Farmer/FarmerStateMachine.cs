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
        public static FarmerActions currentAction => Instance._currentAction;

        private FarmerStateBase _currentState;
        [SerializeField] private FarmerActions _currentAction;
        #endregion

        #region states controller
        protected override void Awake()
        {
            base.Awake();
            dictionaryState = new Dictionary<FarmerActions, FarmerStateBase>();
            dictionaryState.Add(FarmerActions.WALK, new FarmerStateWalk());
            dictionaryState.Add(FarmerActions.WC, new FarmerStateWc());
            dictionaryState.Add(FarmerActions.WELL, new FarmerStateWell());
            dictionaryState.Add(FarmerActions.FARM, new FarmerStateFarm());
            dictionaryState.Add(FarmerActions.TALK, new FarmerStateTalk());
            dictionaryState.Add(FarmerActions.DIE, new FarmerStateDie());
        }

        public void SwitchState(FarmerActions state, FarmerController o)
        {
            if (_currentState != null) _currentState.OnStateExit();
            _currentState = dictionaryState[state];
            _currentAction = state;
            _currentState.OnStateEnter(o);
        }

        private void Update()
        {
            if (_currentState != null) _currentState.OnStateStay();
        }

        public static void ActiveAutoStateChange(float time, FarmerActions exitState, FarmerController farmer)
        {
            Instance.StartCoroutine(Instance.AutomaticStateChange(time, exitState, farmer));
        }
        IEnumerator AutomaticStateChange(float time, FarmerActions exitState, FarmerController farmer)
        {
            yield return new WaitForSeconds(time);
            SwitchState(exitState, farmer);
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
        public static void Die(FarmerController farmer)
        {
            Instance.SwitchState(FarmerActions.DIE, farmer);
        }
        #endregion
    }

}
