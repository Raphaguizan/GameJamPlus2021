using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Cinemachine;

public class ToiletFlushHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    bool holding;
    [SerializeField] float speed;
    Coroutine coroutine;
    [SerializeField] Transform pivot;
    [SerializeField] Transform parent;
    //[SerializeField] 
    Vector3 mousePos;
    List<bool> sequel = new List<bool>();
    int sequelIndex;
    [SerializeField] Toilet toilet;
    // Start is called before the first frame update
    void Start()
    {
        sequel.Add(true);
        sequel.Add(true);
        sequel.Add(false);
        sequel.Add(false);
        sequel.Add(false);
        sequelIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(holding)
        {
            mousePos = Utils.GetMousePosition(pivot);
            SetHandler();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        holding = true;
        if (coroutine != null)
            StopCoroutine(coroutine);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        ReleaseHandler();
    }

    void ReleaseHandler()
    {
        holding = false;
        coroutine = StartCoroutine(SettingInitialPosition());
    }

    void SetHandler()
    {
        Debug.DrawLine(mousePos, pivot.position, Color.red, 5f);
        Vector3 direction = pivot.position - mousePos;
      //  pivot.right = direction;
        pivot.transform.rotation = Quaternion.LookRotation(Vector3.Cross(direction, parent.up), parent.up);

        if(Vector3.SignedAngle(direction, parent.right, parent.up) > 55)
        {
            ReleaseHandler();
            Debug.Log("pra baixo");
            CheckSequel(false);
        }
        else if(Vector3.SignedAngle(direction, parent.right, parent.up) < -55)
        {
            Debug.Log("pra cima");
            ReleaseHandler();
            CheckSequel(true);
        }

    }

    bool CheckSequel(bool answer)
    {
        if(sequel[sequelIndex] == answer)
        {
            sequelIndex++;
            if(sequelIndex == 5)
            {
                toilet.EnterToiletCutscene();
            }

            return true;
        }
        else
        {
            sequelIndex = 0;
            return false;
        }

    }
    IEnumerator SettingInitialPosition()
    {
        float factor = 0;
        Quaternion startRot = this.pivot.transform.rotation;
        Quaternion finalRot = this.parent.rotation;

        while (factor < 1)
        {
            factor += Time.deltaTime * speed;
            transform.rotation = Quaternion.Lerp(startRot, finalRot, factor);

            yield return null;
        }
    }

}
