using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChickenThoughts : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] List<string> seenPhrases = new List<string>();
    [SerializeField] List<string> unlockedPhrases = new List<string>();
    [SerializeField] List<string> lockedPhrases = new List<string>();
    [SerializeField] TextMeshProUGUI text;

    Coroutine coroutine;
    bool thinking;
   
    public void LockedThink()
    {
        if (coroutine != null) StopCoroutine(coroutine);
        text.text = lockedPhrases[Random.Range(0, lockedPhrases.Count)];
        coroutine  = StartCoroutine(Thinking());
    }

    public void UnlockedThink()
    {
        if (coroutine != null) StopCoroutine(coroutine);
        text.text = unlockedPhrases[Random.Range(0, unlockedPhrases.Count)];
        coroutine = StartCoroutine(Thinking());
    }

    public void SeenThink()
    {
        if (coroutine != null) StopCoroutine(coroutine);
        text.text = seenPhrases[Random.Range(0, seenPhrases.Count)];
        coroutine = StartCoroutine(Thinking());
    }

    public void Think(string line)
    {
        if (coroutine != null) StopCoroutine(coroutine);
        text.text = line;
        coroutine = StartCoroutine(Thinking());
    }

    public void StopThinking()
    {
        if (!thinking) return;
        text.gameObject.SetActive(false);
        anim.SetBool("open", false);
        thinking = false;
    }

    IEnumerator Thinking()
    {
        thinking = true;
        anim.SetBool("Open", true);
        yield return new WaitForSeconds(1f);
        text.gameObject.SetActive(true);

        yield return new WaitForSeconds(3f);

        text.gameObject.SetActive(false);
        anim.SetBool("Open", false);
        thinking = false;
    }

   
}
