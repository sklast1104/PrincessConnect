using System;
using UnityEngine;
using DG.Tweening;

namespace Jun.UI.BotNav
{
    public class IconTween : MonoBehaviour
    {
        [SerializeField]
        RectTransform rectTransform;

        [SerializeField]
        private float elapsedTime = 2f;
        [SerializeField]
        private float loopTime = 2f;

        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
        }

        private void Update()
        {
            elapsedTime += Time.deltaTime;

            if (elapsedTime > loopTime)
            {
                elapsedTime = 0f;
                RelativeIconEffect();
            }
        }

        private void OnEnable()
        {
            elapsedTime = 2.1f;
        }

        private void IconEffect()
        {
            rectTransform.DOAnchorPos(new Vector2(13, 65), 0.2f).SetEase(Ease.OutQuad);
            rectTransform.DOAnchorPos(new Vector2(13, 35), 0.2f).SetEase(Ease.OutQuad).SetDelay(0.2f);
            rectTransform.DOShakeScale(0.5f, new Vector3(0f, 0.2f, 0f), 10, 0).SetDelay(0.3f).SetEase(Ease.OutQuad);
        }

        private void RelativeIconEffect()
        {
            rectTransform.DOAnchorPos(new Vector2(0, 30), 0.2f).SetEase(Ease.OutQuad).SetRelative();
            rectTransform.DOAnchorPos(new Vector2(0, -30), 0.2f).SetEase(Ease.OutQuad).SetDelay(0.2f).SetRelative();
            rectTransform.DOShakeScale(0.5f, new Vector3(0f, 0.2f, 0f), 10, 0).SetDelay(0.3f).SetEase(Ease.OutQuad);
        }
    }
}
