using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.MiniMap
{
    public class MiniMapPingBase : MonoBehaviour
    {
        public virtual void ChangeState(MiniMapPingState state) { }
    }
}