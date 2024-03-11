using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class GachaFader : MonoBehaviour
{
    public GameObject top;
    public GameObject bot;

    private CanvasGroup _group;
    private GachaAnoterBg _anoterBg;

    private void Awake()
    {
        _anoterBg = FindObjectOfType<GachaAnoterBg>(true);
        _group = GetComponent<CanvasGroup>();
    }

    public void StartFade()
    {
        _group.DOFade(1, 1f).OnComplete((() =>
        {
            _anoterBg.gameObject.SetActive(true);
        }));
        top.GetComponent<RectTransform>().DOMove(new Vector3(0, -30, 0), 0.5f).SetRelative();
        bot.GetComponent<RectTransform>().DOMove(new Vector3(0, 30, 0), 0.5f).SetRelative();

       
        
        _group.DOFade(0, 1f).SetDelay(1f);
        top.GetComponent<RectTransform>().DOMove(new Vector3(0, 30, 0), 0.5f).SetRelative().SetDelay(1f);
        bot.GetComponent<RectTransform>().DOMove(new Vector3(0, -30, 0), 0.5f).SetRelative().SetDelay(1f);
    }
}
