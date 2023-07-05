using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Chicken;


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

        [Header("SetUp")]
        [SerializeField, Range(1f, 50f)]
        private float _minimapZoom = 5f;

        private void OnValidate()
        {
            _minimapCamera.orthographicSize = _minimapZoom;
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
    }
}