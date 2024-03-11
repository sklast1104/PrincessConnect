using System;
using UnityEngine;
using DG.Tweening;
using Jun.Scene.Main;
using Jun.UI.Common;
using Jun.UI.MainUI;

namespace Jun.UI.QuestUI
{
    public class QuestUIEffect : MonoBehaviour, Fadable
    {
        private MainScene _mainScene;
        private MainUIManager _mainUIManager;
        private CanvasGroup _group;
        
        private void Awake()
        {
            _mainScene = FindObjectOfType<MainScene>();
            _group = GetComponent<CanvasGroup>();
            _mainUIManager = FindObjectOfType<MainUIManager>();
        }

        public void FadeIn()
        {
            _group.DOFade(1f, 1f).SetDelay(0.3f).OnComplete(FadeInComplete);
        }

        public void FadeOut()
        {
            _group.DOFade(0f, 1f).SetDelay(0.3f).OnComplete(FadeOutComplete);
        }

        private void FadeInComplete()
        {
            _mainUIManager.gameObject.SetActive(false);
            _mainScene.EnableNavStatus(MainScene.NavStatus.Quest);
        }

        private void FadeOutComplete()
        {
            gameObject.SetActive(false);
        }
    } 
}


