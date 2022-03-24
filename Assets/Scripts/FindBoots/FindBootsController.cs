using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class FindBootsController : MonoBehaviour
{
    [SerializeField] private Transform _bounderies;
    [SerializeField] private GameObject _boots;

    private List<Vector3> _bounderiesPos;


    private void OnEnable()
    {
        TimeController.TimeChange += VerifyBootState;
    }
    private void OnDisable()
    {
        TimeController.TimeChange -= VerifyBootState;
    }

    void Start()
    {
        _bounderiesPos = new List<Vector3>();
        foreach (Transform b in _bounderies)
        {
            _bounderiesPos.Add(b.position);
        }
    }

    private void VerifyBootState()
    {
        if (TimeController.IsDay)
            DisabeBoot();
        else
            SpawnBoot();
    }

    public void SpawnBoot()
    {
        _boots.transform.position = RandomPos();
        _boots.SetActive(true);
    }

    public void DisabeBoot()
    {
        _boots.SetActive(false);
    }

    private Vector3 RandomPos()
    {
        float respx = Random.Range(_bounderiesPos.Min(v => v.x), _bounderiesPos.Max(v => v.x));
        float respz = Random.Range(_bounderiesPos.Min(v => v.z), _bounderiesPos.Max(v => v.z));
        Vector3 finalPos = new Vector3(respx, 10f, respz);
        RaycastHit hit;
        if (Physics.Raycast(finalPos, transform.TransformDirection(-Vector3.up), out hit, Mathf.Infinity) && hit.transform.CompareTag("ground"))
        {
            finalPos.y = hit.point.y;
        }
        else
        {
            return RandomPos();
        }

        return finalPos;
    }

}
