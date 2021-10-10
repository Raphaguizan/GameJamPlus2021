using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIItemManager : MonoBehaviour
{
    public SO_Bag bag;
    public GameObject itemPrefab;
    private List<GameObject> UIList;
    private void OnEnable()
    {
        UIList = new List<GameObject>();
        ChickenBag.UpdateInterface += UpdateUI;
    }
    private void OnDisable()
    {
        ChickenBag.UpdateInterface -= UpdateUI;
    }

    private void UpdateUI()
    {
        Debug.Log("chegou aki");
        CleanInterface();
        for (int i = 0; i < bag.itens.Count; i++)
        {
            var aux = Instantiate(itemPrefab, transform);
            aux.GetComponent<ItemUI>().Initialize(bag.itens[i]);
            UIList.Add(aux);
        }
    }

    private void CleanInterface()
    {
        Debug.Log("chegou aki clean");
        for (int i = 0; i < UIList.Count; i++)
        {
            Destroy(UIList[i]);
        }
        UIList.Clear();
    }
}
