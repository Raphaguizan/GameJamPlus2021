using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Util;

namespace Game.Chicken
{
    [RequireComponent(typeof(Chicken))]
    public class ChickenPowerUps : Singleton<ChickenPowerUps>
    {
        private Chicken chicken;

        [Space, Header("KongFu")]
        [SerializeField]
        private ShowTutorial hitTutorial;
        public HitController chickenHit;
        public bool HitEnabled => chickenHit.gameObject.activeInHierarchy;

        [Header("Jump Boots")]
        [SerializeField]
        private ShowTutorial bootsTutorial;
        [SerializeField] float bootsJumpForce = 8;
        [HideInInspector]public bool bootsEnabled = false;

        [Header("Parachute")]
        [SerializeField]
        private GameObject parachute;
        public bool parachuteEnabled => parachute.activeInHierarchy;

        protected override void Awake()
        {
            base.Awake();
            chicken = GetComponent<Chicken>();
        }
        private void Start()
        {
            chickenHit.gameObject.SetActive(false);
            parachute.SetActive(false);
        }

        #region static Actives

        public static void ActiveBoots()
        {
            if (Instance.bootsTutorial) Instance.bootsTutorial.Show();
            Instance.bootsEnabled = true;
            Instance.chicken.JumpForce = Instance.bootsJumpForce;
        }
        public static void ActiveKongFu()
        {
            if (Instance.hitTutorial) Instance.hitTutorial.Show();
            Instance.chickenHit.gameObject.SetActive(true);
        }
        public static void ActiveParachute()
        {
            Instance.parachute.SetActive(true);
        }
        #endregion
    }

}
