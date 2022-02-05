using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VolumetricLines;

public class LightSpeed : MonoBehaviour
{
    List<VolumetricLineBehavior> stars = new List<VolumetricLineBehavior>();
    bool accelerating = false;
    bool stoped = false;
    bool finished = false;
    [SerializeField] float speed;
    [SerializeField] float speed2;
    [SerializeField] float minValue;
    float factor = 0;
    // Start is called before the first frame update
    void Start()
    {
        GetStars();
    }

    // Update is called once per frame
    void Update()
    {
        if (finished) return;
        if (!accelerating) return;

        if (factor > 0.5f)
        {
            factor = .5f;
            foreach (VolumetricLineBehavior vlb in stars)
            {
                Vector3 pos = new Vector3(0, factor, 0);
                vlb.StartPos = pos;
            }
            finished = true;
            return;
        }
        

        if (stoped)
        {
            factor += speed2 * Time.deltaTime;
            foreach (VolumetricLineBehavior vlb in stars)
            {
                Vector3 pos = new Vector3(0, factor, 0);
                vlb.StartPos = pos;
            }
            return;
        }
        if (factor < minValue) return;

       
        factor -= speed * Time.deltaTime;
        foreach (VolumetricLineBehavior vlb in stars)
        {
            Vector3 pos = new Vector3(0, factor, 0);
            vlb.StartPos = pos;
        }
    }

    void GetStars()
    {
        foreach (Transform t in this.transform)
        {
            VolumetricLineBehavior vlb = t.GetComponent<VolumetricLineBehavior>();

            stars.Add(vlb);
        }
    }

    public void Accelerate()
    {
        accelerating = true;
        factor = 0.5f;
    }

    public void Stop()
    {
        stoped = true;

    }
}
