using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardPin : MonoBehaviour
{
    [SerializeField] List<Transform> pinsExt;
    [SerializeField] List<Transform> pinsInt;
    [SerializeField] float zPos;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        SetPositions();
    }
    void SetPositions()
    {
        int pinIntIndex = 0;
        for (int i = 0; i < pinsExt.Count; i++)
        {
            Transform pinExt = pinsExt[i];
            Vector3 pinExtPos = pinExt.position;
            pinExtPos.z = zPos;

            pinIntIndex = i - 1;
            if (pinIntIndex < 0) pinIntIndex = pinsInt.Count - 1;

            Transform pinInt1 = pinsInt[pinIntIndex];
            Vector3 pinInt1Pos = pinInt1.position;
            pinInt1Pos.z = zPos;
            Transform pinInt2 = pinsInt[i];
            Vector3 pinInt2Pos = pinInt2.position;
            pinInt2Pos.z = zPos;

            LineRenderer line = pinExt.GetComponent<LineRenderer>();
            line.positionCount = 3;
            line.SetPositions(new Vector3[] { pinInt1Pos, pinExtPos, pinInt2Pos });

        }

        for (int i = 0; i < pinsInt.Count; i++)
        {
            Transform pinInt = pinsInt[i];
            Vector3 pinIntPos = pinInt.position;
            pinIntPos.z = zPos;
            pinIntIndex = i + 1;
            if (pinIntIndex > pinsInt.Count - 1) pinIntIndex = 0;

            Transform pinInt2 = pinsInt[pinIntIndex];
            Vector3 pinInt2Pos = pinInt2.position;
            pinInt2Pos.z = zPos;
            LineRenderer line = pinInt.GetComponent<LineRenderer>();
            line.positionCount = 2;
            line.SetPositions(new Vector3[] { pinIntPos, pinInt2Pos });


        }
    }
}
