using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Util;
using NaughtyAttributes;

namespace Game.MiniMap
{
    public class MiniMapPingManager : Singleton<MiniMapPingManager>
    {
        [SerializeField]
        private MiniMapHUDCtrl _HUDCtrl;

        [SerializeField]
        private Sprite _unknowSprite;

        public static Sprite UnknowSprite => Instance._unknowSprite;
        public static void ChangePingState(MiniMapPingBase ping, MiniMapPingState state)
        {
            ping.ChangeState(state);
        }

        public static void StartObjective(MiniMapObjective ping)
        {
            Instance._HUDCtrl.NewObjectivePing(ping);
        }

        #region Teste
        [Header("TESTE")]
        public MiniMapPingBase pingTeste;
        public MiniMapPingState stateTeste;

        [Button]
        public void SetPingState()
        {
            ChangePingState(pingTeste, stateTeste);
        }
        #endregion
    }
}