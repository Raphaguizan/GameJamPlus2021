using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Minigame.Tombstone
{
    public class TombStoneObj : MonoBehaviour
    {
        [SerializeField, NaughtyAttributes.ReadOnly]
        private bool isActive = false;

        [Space, SerializeField]
        private int row;
        [SerializeField]
        private int col;

        [Space, SerializeField]
        private GameObject candle;


        public bool IsActive => isActive;

        private TombstoneController controller;
        private bool canInteract = true;

        private void Awake()
        {
            Disable();
            controller = gameObject.GetComponentInParent<TombstoneController>();

            if (controller) controller.OnWin.AddListener(DisableInteraction);
            else Debug.LogError("Controller da lápide (" + row + ", " + col + ") está nulo!");
        }

        public void PlayerToogle()
        {
            if (!canInteract) return;
            
            // chama controller;
            if (controller) controller.InteractionSpread(row, col);
        }
        public void Toogle()
        {
            isActive = !isActive;
            candle.SetActive(isActive);
        }

        public void Disable()
        {
            isActive = false;
            candle.SetActive(false);
        }

        private void DisableInteraction()
        {
            canInteract = false;
        }
    }
}