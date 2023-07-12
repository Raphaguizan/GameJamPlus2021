using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraInTube : MonoBehaviour
{
    Transform nextTube;
    [SerializeField] float speed;
    [SerializeField] Transform currentTube;
    bool onGame;
    Vector3 nextPoint;
    Quaternion currentRotation;
    Quaternion nextRotation;
    // Start is called before the first frame update
    void Start()
    {
        SetUp();

    }

    void SetUp()
    {
        this.transform.position = currentTube.position;
        nextTube = TubeManager.Instance.GetNextTube();
        Vector3 direction = (nextTube.position - currentTube.position);
        nextPoint = currentTube.position + (Vector3.Distance(currentTube.position, nextTube.position) / 2) * direction.normalized;
        //  this.transform.forward = nextTube.position - currentTube.position;
        currentRotation = transform.rotation;
        nextRotation = Quaternion.LookRotation(nextPoint - currentTube.position);
        onGame = true;
        StartCoroutine(Running());
    }
    // Update is called once per frame
    void Update()
    {

    }

    void NextTube()
    {
        currentTube = nextTube;
        this.nextTube = TubeManager.Instance.GetNextTube();
        Vector3 direction = (nextTube.position - currentTube.position);
        nextPoint = currentTube.position + (Vector3.Distance(currentTube.position, nextTube.position) / 2) * direction.normalized;
        //  this.transform.forward = nextTube.position - currentTube.position;
        currentRotation = transform.rotation;
        nextRotation = Quaternion.LookRotation(nextPoint - currentTube.position);
    }

    void SetRotation()
    {
        currentRotation = transform.rotation;
        nextRotation = Quaternion.LookRotation(TubeManager.Instance.GetNextTube2().position - nextTube.position);
    }

    IEnumerator Running()
    {
        float factor = 0;

        while (onGame)
        {
            while (factor < 1)
            {
                factor += Time.deltaTime * speed;

                transform.position = Vector3.Lerp(currentTube.position, nextTube.position, factor);

                if(factor > .5f)
                {
                    SetRotation();
                }
                transform.rotation = Quaternion.Lerp(currentRotation, nextRotation, factor);
                yield return null;
            }

            factor = 0;
            NextTube();

        }
    }
}
