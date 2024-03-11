using System;
using Jun.UI;
using UnityEngine;
using DG.Tweening;

public class MainPanelEffect : MonoBehaviour, Fadable
{
    private RectTransform rectTransform;
    private CanvasGroup group;

    [SerializeField]
    private Vector3 destPos;

    private Vector3 startPos;

    [SerializeField] private float delay = 0.3f;
    [SerializeField] private float alphaOutDelay = 0.3f;
    
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        group = GetComponent<CanvasGroup>();
        startPos = rectTransform.anchoredPosition;
    }

    public void FadeIn()
    {
        rectTransform.anchoredPosition = destPos;
        rectTransform.DOAnchorPos(startPos, 0.2f).SetEase(Ease.OutQuad);

        group.DOFade(1f, alphaOutDelay);
    }
    
    public void FadeOut()
    {
        rectTransform.DOAnchorPos(new Vector2(destPos.x, destPos.y), delay).SetEase(Ease.OutQuad);
        group.DOFade(0f, alphaOutDelay);
    }
}
