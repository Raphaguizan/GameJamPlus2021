using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Chicken
{
    [RequireComponent(typeof(Chicken))]
    public class InitializeChickenAsset : MonoBehaviour
    {
        [SerializeField]
        private ChickenAsset chickenAsset;

        private void Awake()
        {
            chickenAsset.SetAsset(GetComponent<Chicken>());
        }
    }
}