using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ItemPanelHandler : MonoBehaviour
{
    private List<GameObject> _itemList;
    private Sequence _itemSequence;
    
    private void Awake()
    {
        _itemSequence = DOTween.Sequence();

        _itemList = new List<GameObject>();
        
        for (int i = 0; i < transform.childCount; i++)
        {
            _itemList.Add(transform.GetChild(i).gameObject);
        }
    }

    private void Start()
    {
        StartCoroutine((SequenceActive()));
    }

    IEnumerator SequenceActive()
    {
        yield return new WaitForSeconds(1f);
        
        for (int i = 0; i < _itemList.Count; i++)
        {
            _itemList[i].SetActive(true);

            yield return new WaitForSeconds(0.1f);
        }
    }
}
