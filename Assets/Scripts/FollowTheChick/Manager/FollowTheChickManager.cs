using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.StateMachine;
using Game.Chicken;
using UnityEngine.SceneManagement;

namespace Game.Minigame.FollowTheChick
{
    public class FollowTheChickManager : MonoBehaviour
    {
        public Chicken.Chicken chicken;
        public ChickStateMachine chickStateMachine;

        [Header("Cameras"), SerializeField]
        public GameObject beginCamera;
        [SerializeField]
        public GameObject runCamera;
        [SerializeField]
        public GameObject winCamera;
        [SerializeField]
        public GameObject loseCamera;


        private FollowTheChickStateMachine stateMachine;

        private void Awake()
        {
            stateMachine = GetComponent<FollowTheChickStateMachine>();
            stateMachine.RegisterManager(this);
        }

        private void Start()
        {
            DisableAllCameras();
            stateMachine.Begin();
        }

        public void DisableAllCameras()
        {
            beginCamera.SetActive(false);
            runCamera.SetActive(false);
            winCamera.SetActive(false);
            loseCamera.SetActive(false);
        }

        public void StateWait(FollowTheChickStates state, float time)
        {
            stateMachine.SwitchState(state, time, this);
        }

        public void ReloadScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        public void ReloadScene(float time)
        {
            Invoke(nameof(ReloadScene), time);
        }
    }
}