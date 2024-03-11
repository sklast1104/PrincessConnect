using DG.Tweening;
using System.Collections;
using UnityEngine;

namespace Jun.UI.Common
{
    public class CharaEffect : MonoBehaviour
    {
        private RectTransform rect;
        private Vector2 upVec = new Vector2(0, 20);

        private float delay = 0.5f;

        private void Awake()
        {
            rect = GetComponent<RectTransform>();
        }

        public void PlayEffect()
        {
            rect.DOAnchorPos(upVec, delay).SetRelative(true);
            rect.DOAnchorPos(-upVec, delay).SetRelative(true).SetDelay(delay);
        }
    }
}