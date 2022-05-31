using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Game.Util.Matrix;

namespace Game.Minigame.Tombstone
{
    public class TombstoneController : MonoBehaviour
    {
        [SerializeField]
        private Vector2Int matrixDimensions;

        [SerializeField]
        private List<TombStoneObj> stones;

        [Space]
        public UnityEvent OnWin;

        public void InteractionSpread(int i, int j)
        {
            int aux = -1;

            aux = GetIndex(i + 1, j);
            if (aux >= 0) stones[aux].Toogle();

            aux = GetIndex(i - 1, j);
            if (aux >= 0) stones[aux].Toogle();

            aux = GetIndex(i, j + 1);
            if (aux >= 0) stones[aux].Toogle();

            aux = GetIndex(i, j - 1);
            if (aux >= 0) stones[aux].Toogle();

            VerifyVictory();
        }

        private void VerifyVictory()
        {
            Debug.Log("entrei no Verify");
            foreach (var item in stones)
            {
                if (!item.IsActive)
                {
                    return;
                }
            }
            Debug.Log("Ganhou");

            OnWin.Invoke();
        }

        public int GetIndex(int i, int j)
        {
            if(i >= matrixDimensions.x || j >= matrixDimensions.y || i < 0 || j < 0)return -1;
            return i*matrixDimensions.x + j;
        }
    }
}