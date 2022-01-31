using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class ArtfitialMove : MonoBehaviour
{
    [SerializeField]
    public Transform ObjectToMove;
    public Transform moveTo;
    public float time;
    public Ease ease;
    [Space]
    public UnityEvent completeMoveEvent;

    private bool _startMove = false;
    
    public void Move()
    {
        ObjectToMove.DOMove(moveTo.position, time).SetEase(ease);
        _startMove = true;
    }

    private void Update()
    {
        if (!DOTween.IsTweening(ObjectToMove) && _startMove)
        {
            completeMoveEvent?.Invoke();
        }
    }
}
