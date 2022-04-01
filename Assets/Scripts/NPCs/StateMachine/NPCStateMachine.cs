using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Util;

namespace Game.NPC.StateMachine
{
    public class NPCStateMachine : MonoBehaviour
    {

        #region declaration


        public Dictionary<NPCActions, NPCStateBase> dictionaryState;
        public NPCActions currentAction => _currentAction;

        private NPCStateBase _currentState;
        [SerializeField] private NPCActions _currentAction;
        #endregion

        #region states controller
        private void Awake()
        {
            dictionaryState = new Dictionary<NPCActions, NPCStateBase>();
            dictionaryState.Add(NPCActions.WALK, new FarmerStateWalk());
            dictionaryState.Add(NPCActions.WAIT, new FarmerStateWait());
        }

        public void SwitchState(NPCActions state, RandomIAWalk o)
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

        public void ActiveAutoStateChange(float time, NPCActions exitState, RandomIAWalk ia)
        {
            StartCoroutine(AutomaticStateChange(time, exitState, ia));
        }
        IEnumerator AutomaticStateChange(float time, NPCActions exitState, RandomIAWalk ia)
        {
            yield return new WaitForSeconds(time);
            SwitchState(exitState, ia);
        }
        #endregion

        #region Change State
        public void Walk(RandomIAWalk ia)
        {
            SwitchState(NPCActions.WALK, ia);
        }
        public void Wait(RandomIAWalk ia)
        {
            SwitchState(NPCActions.WAIT, ia);
        }
        #endregion
    }
}
