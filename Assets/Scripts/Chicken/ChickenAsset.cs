using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Chicken
{
    [CreateAssetMenu(menuName ="Game/Chicken/Asset")]
    public class ChickenAsset : ScriptableObject
    {
        private GameObject _currentChickenObj;

        public Chicken ChickenScript;
        public GameObject ChickenObj => _currentChickenObj;

        public void SetAsset(Chicken chicken)
        {
            ChickenScript = chicken;
            _currentChickenObj = chicken.gameObject;
        }
    }
}