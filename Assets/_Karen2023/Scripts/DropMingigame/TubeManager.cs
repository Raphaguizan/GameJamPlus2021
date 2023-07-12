using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-1)]
public class TubeManager : MonoBehaviour
{
    public static TubeManager Instance;
    [SerializeField] Transform tubeHolder;
    List<Transform> tubes = new List<Transform>();
    int tubeIndex;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        SetUp();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SetUp()
    {
        tubeIndex = 0;
        foreach (Transform t in tubeHolder)
        {
            tubes.Add(t);
        }
    }

    public Transform GetNextTube()
    {
        tubeIndex++;
        if (tubeIndex >= tubes.Count)
        {
            Debug.Log("Final");
            return null;
        }
        Transform t = tubes[tubeIndex];

        return t;
    }

    public Transform GetNextTube2()
    {
        int index = tubeIndex + 1;
        if (index >= tubes.Count)
        {
            Debug.Log("Final");
            return null;
        }
        Transform t = tubes[index];

        return t;
    }
}
