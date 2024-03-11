using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CardEffecct : MonoBehaviour
{
    private RectTransform tr;

    private void Awake()
    {
        tr = GetComponent<RectTransform>();
    }

    void Start()
    {
        tr.DOPunchScale(new Vector3(0.3f, 0.3f, 0.3f), 1, 6, 0.25f);
    }
}
