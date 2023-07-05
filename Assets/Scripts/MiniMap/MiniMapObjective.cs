using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.MiniMap
{
    public class MiniMapObjective : MiniMapPing
    {
        public override void ChangeState(MiniMapPingState newState)
        {
            _state = newState;

            Sprite newSpriteAux = newState switch
            {
                MiniMapPingState.HIDE => null,
                MiniMapPingState.UNKNOW => MiniMapPingManager.UnknowSprite,
                MiniMapPingState.UNLOKED => Unlock(),
                _ => null,
            };
            ChangeSprite(newSpriteAux);
        }

        private Sprite Unlock()
        {
            MiniMapPingManager.StartObjective(this);
            return null;
        }
    }
}