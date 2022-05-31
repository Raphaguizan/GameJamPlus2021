using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardPin : MonoBehaviour
{
    [SerializeField] List<Transform> pinsExt;
    [SerializeField] List<Transform> pinsInt;
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

            pinIntIndex = i - 1;
            if (pinIntIndex < 0) pinIntIndex = pinsInt.Count - 1;

            Transform pinInt1 = pinsInt[pinIntIndex];
            Transform pinInt2 = pinsInt[i];

            LineRenderer line = pinExt.GetComponent<LineRenderer>();
            line.positionCount = 3;
            line.SetPositions(new Vector3[] { pinInt1.position, pinExt.position, pinInt2.position });

        }

        for (int i = 0; i < pinsInt.Count; i++)
        {
            Transform pinInt = pinsInt[i];
            pinIntIndex = i + 1;
            if (pinIntIndex > pinsInt.Count - 1) pinIntIndex = 0;

            Transform pinInt2 = pinsInt[pinIntIndex];

            LineRenderer line = pinInt.GetComponent<LineRenderer>();
            line.positionCount = 2;
            line.SetPositions(new Vector3[] { pinInt.position, pinInt2.position });


        }
    }
}
