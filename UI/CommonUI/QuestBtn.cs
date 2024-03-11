using System;
using System.Collections;
using System.Collections.Generic;
using Jun.Scene.Main;
using Jun.UI.MainUI;
using Jun.UI.QuestUI;
using UnityEngine;
using UnityEngine.UI;

namespace Jun.UI.Common
{
    public class QuestBtn : MonoBehaviour
    {
        
        private Button button;
        private MainUIManager mainUIManager;
        private QuestUIManager questUIManager;
        
        private MainScene _mainScene;

        private GameObject _topNavGO;

        private void Awake()
        {
            button = GetComponent<Button>();
            mainUIManager = FindObjectOfType<MainUIManager>(true);
            questUIManager = FindObjectOfType<QuestUIManager>(true);
            _mainScene = FindObjectOfType<MainScene>();
            _topNavGO = FindObjectOfType<TopNavManager>(true).gameObject;
            
            button.onClick.AddListener(OnBtnClicked);
        }

        void OnBtnClicked()
        {
            if (_mainScene.StatusChecker[MainScene.NavStatus.Quest] == false)
            {
                _topNavGO.SetActive(true);
                
                _mainScene.EnableNavBtn(MainScene.NavStatus.Quest);
                
                //mainUIManager.FadeOut();
                _mainScene.EnableUICanvas(MainScene.NavStatus.Quest);
                //questUIManager.gameObject.SetActive(true);
                //questUIManager.FadeIn();
            }
        }
    }
}


