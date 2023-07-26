using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Chicken;
using NaughtyAttributes;
using UnityEngine.UI;

namespace Game.MiniMap
{
    public class MiniMapHUDCtrl : MonoBehaviour
    {
        [SerializeField]
        private Camera _minimapCamera;

        [SerializeField]
        private ChickenAsset _chickenAsset;

        [SerializeField]
        private RectTransform _playerPing;

        [SerializeField]
        private RectTransform _Pings;

        [SerializeField]
        private GameObject _ObjectivePing;

        [Header("SetUp")]
        [SerializeField, Range(1f, 50f)]
        private float _minimapZoom = 5f;

        [SerializeField, ReadOnly]
        private float miniMapRatio;
        private void OnValidate()
        {
            SetMiniMapZoom(_minimapZoom);
        }
        public void SetMiniMapZoom(float val)
        {
            _minimapCamera.orthographicSize = _minimapZoom = val;
            CalculeMiniMapRatio();
        }

        private void Awake()
        {
            CalculeMiniMapRatio();
        }

        private void LateUpdate()
        {
            CameraPosition();
            PlayerPingDirection();
        }

        private void CameraPosition()
        {
            Vector3 posAux = _chickenAsset.ChickenObj.transform.position;
            posAux.y = _minimapCamera.transform.position.y;
            _minimapCamera.transform.position = posAux;
        }

        private void PlayerPingDirection()
        {
            _playerPing.rotation = Quaternion.Euler(0f, 0f, -_chickenAsset.ChickenObj.transform.eulerAngles.y);
        }

        private void CalculeMiniMapRatio()
        {
            //distance world
            Vector3 distanceWorldVector = _chickenAsset.ChickenObj.transform.position - (_chickenAsset.ChickenObj.transform.position + Vector3.right * _minimapZoom);
            distanceWorldVector.y = 0f;
            float distanceWorld = distanceWorldVector.magnitude;

            miniMapRatio = (_Pings.rect.width/ 2) / distanceWorld;
        }

        private Vector2 GetMiniMapPosition(Vector3 worldPos)
        {
            return _Pings.anchoredPosition + ConvertVectorToUI((worldPos - _chickenAsset.ChickenObj.transform.position) * miniMapRatio);
        }

        private Vector2 ConvertVectorToUI(Vector3 vec)
        {
            return new Vector2(vec.x, vec.z);
        }

        #region Objective

        public void NewObjectivePing(MiniMapObjective objective)
        {
            StartCoroutine(ActiveObjective(objective));
        }

        IEnumerator ActiveObjective(MiniMapObjective objective)
        {
            RectTransform myPing = CreateNewObjectivePing(objective.UnlockedSprite);
            while (objective.State == MiniMapPingState.UNLOKED)
            {
                Vector2 realPosition = GetMiniMapPosition(objective.transform.position);
                myPing.anchoredPosition = MiniMapBounderies(realPosition);
                yield return new WaitForEndOfFrame();
            }
            Destroy(myPing.gameObject);
        }

        private Vector2 MiniMapBounderies(Vector2 position)
        {
            float pointDistance = Vector2.Distance(_Pings.anchoredPosition, position);
            if(pointDistance > _Pings.rect.width / 2)
            {
                return (position - _Pings.anchoredPosition).normalized * (_Pings.rect.width / 2);
            }
            return position;
        }

        private RectTransform CreateNewObjectivePing(Sprite image)
        {
            var newPing = Instantiate(_ObjectivePing, _Pings);
            newPing.GetComponentInChildren<Image>().sprite = image;
            return newPing.GetComponent<RectTransform>();
        }

        #endregion

        #region Teste
        [Header("Teste")]
        public MiniMapObjective TesteObjective;
        [Button]
        public void TestePoint()
        {
            NewObjectivePing(TesteObjective);
        }
        #endregion
    }
}