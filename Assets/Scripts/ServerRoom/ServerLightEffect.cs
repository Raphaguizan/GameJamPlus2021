using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerLightEffect : MonoBehaviour
{
    [SerializeField, Tooltip("Random time in seconds")]
    private Vector2 randomTime;
    [SerializeField]
    private List<GameObject> lights;

    [SerializeField, ColorUsage(true, true)]
    private List<Color> colors;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ChangeColor());
    }

    IEnumerator ChangeColor()
    {
        while (true)
        {
            var mesh = lights[Random.Range(0, lights.Count)].GetComponent<MeshRenderer>();
            mesh.material.SetColor("_EmissionColor", colors[Random.Range(0, colors.Count)]);
            yield return new WaitForSeconds(Random.Range(randomTime.x, randomTime.y));
        }
    }
}
