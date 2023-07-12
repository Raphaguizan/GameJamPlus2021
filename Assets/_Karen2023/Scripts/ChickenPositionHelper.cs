using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenPositionHelper : MonoBehaviour
{
    Vector3 nextPosition;
    Quaternion nextRotation;
    [SerializeField] float speed = 5;
    string animation;
    Animator anim;
    Action onComplete;
    private void Start()
    {
        anim = this.GetComponent<Animator>();
    }
    public void SetPosition(Transform target, string animation = "Jump")
    {
        nextPosition = target.position;
        nextRotation = target.rotation;
        this.animation = animation;
        StartCoroutine(SettingNewPosition());
    }

    void SetAnimation()
    {
        anim.SetTrigger(this.animation);
    }
    IEnumerator SettingNewPosition()
    {
        SetAnimation();
        float factor = 0;
        Vector3 startPos = this.transform.position;
        Quaternion startRot = this.transform.rotation;

        while(factor < 1)
        {
            factor += Time.deltaTime * speed;
            transform.position = Vector3.Lerp(startPos, nextPosition, factor);
            transform.rotation = Quaternion.Lerp(startRot, nextRotation, factor);
            yield return null;
        }

        onComplete?.Invoke();

        yield return new WaitForSeconds(2f);

        this.gameObject.SetActive(false);
    }
}
