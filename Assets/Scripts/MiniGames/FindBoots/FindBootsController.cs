using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using Game.Chicken;
using Game.Util;

public class FindBootsController : MonoBehaviour
{
    [SerializeField] private Transform _bounderies;
    [SerializeField] private GameObject _boots;

    [Header("Beep"),SerializeField] 
    private AudioSource sound;
    [SerializeField]
    private Vector2 beepDelay;

    [Space, SerializeField, NaughtyAttributes.ReadOnly]
    private bool isBeeping;

    private List<Vector3> _bounderiesPos;
    private Coroutine _beepCoroutine = null;
    private Transform chickenTrans;
    private GameObject bootArt;
    private BootBeepAnimatorController beepAnimation;
    private readonly float _MaxDist = 45f;

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
        if(_boots) beepAnimation = _boots.GetComponent<BootBeepAnimatorController>();
        bootArt = _boots.GetComponent<CollectItemBase>().Art;

        _bounderiesPos = new List<Vector3>();
        foreach (Transform b in _bounderies)
        {
            _bounderiesPos.Add(b.position);
        }
    }

    private void VerifyBootState()
    {
        if (!_boots) return;
        if (TimeController.IsDay)
        {
            DisabeBoot();
            StopBeep();
        }
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

    #region Beep
    private void OnTriggerStay(Collider other)
    {
        if (isBeeping || !_boots || !bootArt.activeInHierarchy) return;
        var chicken = other.GetComponent<Chicken>();
        if (chicken)
        {
            chickenTrans = chicken.transform;
            _beepCoroutine = StartCoroutine(BeepCoroutine());
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Chicken>() && isBeeping)
        {
            StopBeep();
        }
    }

    private IEnumerator BeepCoroutine()
    {
        isBeeping = true;
        while (isBeeping)
        {
            float beepTime = ChickenDistance().Remap(0, _MaxDist, beepDelay.x, beepDelay.y);
            yield return new WaitForSeconds(beepTime);
            beepAnimation.BeepLight();
            sound.Play();
        }
    }

    private float ChickenDistance()
    {
        return Vector3.Distance(chickenTrans.position, _boots.transform.position);
    }

    public void StopBeep()
    {
        isBeeping = false;
        if (_beepCoroutine == null) return;
        StopCoroutine(_beepCoroutine);
        _beepCoroutine = null;
    }
    #endregion
}
