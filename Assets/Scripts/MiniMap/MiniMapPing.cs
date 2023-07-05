using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

namespace Game.MiniMap
{
    public class MiniMapPing : MiniMapPingBase
    {
        [SerializeField, ReadOnly]
        protected MiniMapPingState _state;

        [SerializeField]
        protected GameObject _pingPrefab;

        [SerializeField]
        protected Sprite _unlockedsprite;


        [Header("Setup")]
        [SerializeField]
        protected float _pingSize;

        protected GameObject _pingGameObj;
        protected SpriteRenderer _pingSpriteRenderer;


        public MiniMapPingState State => _state;

        public Sprite UnlockedSprite => _unlockedsprite;

        protected virtual void Awake()
        {
            InitializePing(MiniMapPingState.HIDE);
        }

        public void InitializePing(MiniMapPingState state)
        {
            CreatePingObj();
            _pingSpriteRenderer = _pingGameObj.GetComponent<SpriteRenderer>();
            ChangeState(state);
        }

        private void CreatePingObj()
        {
            var newPing = Instantiate(_pingPrefab, this.transform);
            newPing.transform.localScale = Vector3.one*_pingSize;
            _pingGameObj = newPing;
        }

        protected virtual void LateUpdate()
        {
            _pingGameObj.transform.rotation = Quaternion.Euler(90f, 0f, 0f);
        }

        public override void ChangeState(MiniMapPingState newState)
        {
            _state = newState;

            Sprite newSpriteAux = newState switch
            {
                MiniMapPingState.HIDE => null,
                MiniMapPingState.UNKNOW => MiniMapPingManager.UnknowSprite,
                MiniMapPingState.UNLOKED => UnlockedSprite,
                _ => _pingSpriteRenderer.sprite,
            };
            ChangeSprite(newSpriteAux);
        }

        protected void ChangeSprite(Sprite newSprite)
        {
            _pingSpriteRenderer.sprite = newSprite;
        }
 
    }
}