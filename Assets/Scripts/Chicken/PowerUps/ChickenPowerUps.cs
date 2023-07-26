using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Game.Util;
using NaughtyAttributes;

namespace Game.Chicken
{
    [RequireComponent(typeof(Chicken))]
    public class ChickenPowerUps : Singleton<ChickenPowerUps>
    {
        [SerializeField]
        private List<ChickenPowerUpBase> powerUps;

        public static void ActivePowerUp(PowerUpType powerUp)
        {
            Instance.FindPowerUpByType(powerUp)?.ActivePowerUp();
        }

        public static bool IsPowerUpActive(PowerUpType powerUp)
        {
            var currentPowerUp = Instance.FindPowerUpByType(powerUp);

            if (currentPowerUp == null)
                return false;

            return currentPowerUp.IsActive;
        }

        public static void PowerUpInteract(PowerUpType powerUp)
        {
            Instance.FindPowerUpByType(powerUp)?.Interact();
        }

        public static void DisablePowerUp(PowerUpType powerUp)
        {
            Instance.FindPowerUpByType(powerUp)?.DisabePowerUp();
        }

        private ChickenPowerUpBase FindPowerUpByType(PowerUpType powerUp)
        {
            return powerUps.Find(p => p.Name == powerUp);
        }



        #region Editor Teste
        [Button(enabledMode: EButtonEnableMode.Playmode)]
        private void ActiveBoots()
        {
            ActivePowerUp(PowerUpType.BOOTS);
        }
        [Button(enabledMode: EButtonEnableMode.Playmode)]
        private void DisableBoots()
        {
            DisablePowerUp(PowerUpType.BOOTS);
        }


        [Button(enabledMode: EButtonEnableMode.Playmode)]
        private void ActiveParachute()
        {
            ActivePowerUp(PowerUpType.PARACHUTE);
        }
        [Button(enabledMode: EButtonEnableMode.Playmode)]
        private void DisableParachute()
        {
            DisablePowerUp(PowerUpType.PARACHUTE);
        }

        [Button(enabledMode: EButtonEnableMode.Playmode)]
        private void ActiveKungFu()
        {
            ActivePowerUp(PowerUpType.KUNGFU);
        }
        [Button(enabledMode: EButtonEnableMode.Playmode)]
        private void DisableKungFu()
        {
            DisablePowerUp(PowerUpType.KUNGFU);
        }

        #endregion





        ///////////////////////////////////////////////////////////
        //private Chicken chicken;

        //[Space, Header("KongFu")]
        //[SerializeField]
        //private ShowTutorial hitTutorial;
        //public HitController chickenHit;
        //public bool HitEnabled => chickenHit.gameObject.activeInHierarchy;
        //public UnityEvent onActiveKungFu;

        //[Header("Jump Boots")]
        //[SerializeField]
        //private ShowTutorial bootsTutorial;
        //[SerializeField] float bootsJumpForce = 8;
        //[HideInInspector]public bool bootsEnabled = false;
        //public UnityEvent onActiveBoots;

        //[Header("Parachute")]
        //[SerializeField]
        //private GameObject parachute;
        //public bool parachuteEnabled => parachute.activeInHierarchy;
        //public UnityEvent onActiveParachute;

        //protected override void Awake()
        //{
        //    base.Awake();
        //    chicken = GetComponent<Chicken>();
        //}
        //private void Start()
        //{
        //    chickenHit.gameObject.SetActive(false);
        //    parachute.SetActive(false);
        //}

        //#region static Actives

        //[Button]
        //public static void ActiveBoots()
        //{
        //    if (Instance.bootsTutorial) Instance.bootsTutorial.Show();
        //    Instance.bootsEnabled = true;
        //    Instance.chicken.JumpForce = Instance.bootsJumpForce;
        //    Instance.onActiveBoots.Invoke();
        //}
        //[Button]
        //public static void ActiveKungFu()
        //{
        //    if (Instance.hitTutorial) Instance.hitTutorial.Show();
        //    Instance.chickenHit.gameObject.SetActive(true);
        //    Instance.onActiveKungFu.Invoke();
        //}
        //[Button]
        //public static void ActiveParachute()
        //{
        //    Instance.parachute.SetActive(true);
        //    Instance.onActiveParachute.Invoke();
        //}
        //#endregion
    }

}
