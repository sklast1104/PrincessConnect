using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class TopWallEff : MonoBehaviour
{
    private Vector3 origin;
    private RectTransform _rectTransform;
    
    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        origin = _rectTransform.position;
    }

    private void OnEnable()
    {
        _rectTransform.position = origin;
        _rectTransform.DOLocalMove(new Vector3(150, 0, 0), 0.8f).SetRelative(true);
    }

    private void Start()
    {
        
    }
}
