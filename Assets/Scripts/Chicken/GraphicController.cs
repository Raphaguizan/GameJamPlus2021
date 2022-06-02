using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Chicken
{
    public class GraphicController : MonoBehaviour
    {
        [SerializeField]
        private List<GameObject> _graphics;

        public void ActiveGraphic(bool val)
        {
            foreach (GameObject go in _graphics)
            {
                go.SetActive(val);
            }
        }
    }
}