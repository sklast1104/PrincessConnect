using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Jun.Scene.Main;
using Jun.UI.Common;
using Spine.Unity;
using UnityEngine;

namespace Jun.UI.MainUI
{
    public class MainCharacterUI : MonoBehaviour
    {
        private SkeletonGraphic graphic;
        private MainScene _mainScene;

        [SerializeField] private float delay = 0.3f;
    
        private void Awake()
        {
            graphic = GetComponent<SkeletonGraphic>();
            _mainScene = FindObjectOfType<MainScene>();
        }

        public void FadeIn()
        {
            graphic.DOFade(1f, delay).SetEase(Ease.OutQuad).OnComplete((() =>
            {
                _mainScene.EnableNavStatus(MainScene.NavStatus.MyPage);
            }));
        }

        public void FadeOut()
        {
            graphic.DOFade(0f, delay).SetEase(Ease.OutQuad);
        }
    }
}


