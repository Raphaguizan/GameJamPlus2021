using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Game.NPC;
using TMPro;

public class GroupChickenController : MonoBehaviour
{
    [SerializeField]
    private  int CountMax = 8;
    [SerializeField, NaughtyAttributes.ReadOnly]
    private int ChickenCount = 0;

    [Space, SerializeField]
    private Animator interfaceCount;
    [SerializeField]
    private TextMeshPro text;

    [Space, SerializeField]
    private float stopFollowDelay = .5f;

    [Space]
    public UnityEvent onWin;

    private void OnTriggerEnter(Collider other)
    {
        var npc = other.GetComponent<RandomIAWalk>();
        if (npc)
        {
            UpdateChikenCount(1);
            StartCoroutine(DelayStopFollow(npc));
        }
    }
    private void OnTriggerExit(Collider other)
    {
        var npc = other.GetComponent<RandomIAWalk>();
        if (npc)
        {
            UpdateChikenCount(-1);
        }
    }

    private void UpdateChikenCount(int sum)
    {
        ChickenCount += sum;
        if(ChickenCount <= 0)
        {
            ChickenCount = 0;
            interfaceCount.SetBool("Show", false);
        }
        else if(ChickenCount >= CountMax)
        {
            text.text = ChickenCount.ToString("0");
            onWin.Invoke();
        }
        else
        {
            interfaceCount.SetBool("Show", true);
            text.text = ChickenCount.ToString("0");
        }
    }

    private IEnumerator DelayStopFollow(RandomIAWalk npc)
    {
        yield return new WaitForSeconds(stopFollowDelay);
        if (npc) npc.stateMachine.Stop(npc);
    }
}
