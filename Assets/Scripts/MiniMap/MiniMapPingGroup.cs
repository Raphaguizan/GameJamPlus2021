using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.MiniMap
{
    public class MiniMapPingGroup : MiniMapPingBase
    {
        [SerializeField]
        private List<MiniMapPingBase> _miniMapPinglist;

        public override void ChangeState(MiniMapPingState state)
        {
            foreach (var ping in _miniMapPinglist)
            {
                ping.ChangeState(state);
            }
        }
    }
}