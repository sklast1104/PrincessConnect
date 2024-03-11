using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Jun.UI.BattleScene
{
    public class ExpUIHandler : UI_Base
    {
        public Action EndEvent;
        
        enum Buttons
        {
            Next_Btn,
        }

        enum GameObjects
        {
            Star_Container,
            PlayerExpBar,
            Char_Exp_Container,
            Next_Btn,
        }

        private ItemUIHandler _itemUIHandler;
        
        private void Awake()
        {
            _itemUIHandler = FindObjectOfType<ItemUIHandler>(true);
            
            Init();
            
            Button _nextBtn = Get<Button>(0);
            _nextBtn.onClick.AddListener((() =>
            {
                EndEvent?.Invoke();
            }));  
        }

        public override void Init()
        {
            Bind<Button>(typeof(Buttons));
            Bind<GameObject>(typeof(GameObjects));
        }

        private void OnEnable()
        {
            EndEvent += NextBtnEventHandler;
        }

        private void OnDisable()
        {
            EndEvent -= NextBtnEventHandler;
        }

        void NextBtnEventHandler()
        {
            for (int i = 0; i < 4; i++)
            {
                GameObject _starContainer = Get<GameObject>(i);
                _starContainer.GetComponent<RectTransform>().DOAnchorPos(new Vector2(0, 10), 0.5f).SetRelative();
                _starContainer.GetComponent<CanvasGroup>().DOFade(0f, 0.5f).OnComplete((() =>
                {
                    _starContainer.gameObject.SetActive(false);
                    _itemUIHandler.gameObject.SetActive(true);
                }));
            }
        }
    }
}


