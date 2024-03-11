using System;
using Jun.Scene.Main;
using Jun.UI.GachaUI;
using Jun.UI.MainUI;
using Jun.UI.QuestUI;
using UnityEngine;
using UnityEngine.UI;

namespace Jun.UI.Common
{
    
    public class GachBtnInAct : MonoBehaviour
    {
        private Button button;
        private GachaUIManager _gachaUIManager;
        private MainScene _mainScene;
        private GameObject _topNavGO;
        
        private void Awake()
        {
            button = GetComponent<Button>();
            _gachaUIManager = FindObjectOfType<GachaUIManager>(true);
            _mainScene = FindObjectOfType<MainScene>();
            _topNavGO = FindObjectOfType<TopNavManager>(true).gameObject;
            
            button.onClick.AddListener(OnBtnClicked);
        }

        void OnBtnClicked()
        {
            if (_mainScene.StatusChecker[MainScene.NavStatus.Gacha] == false)
            {
                _topNavGO.SetActive(true);
                
                _mainScene.EnableNavBtn(MainScene.NavStatus.Gacha);
                _mainScene.EnableUICanvas(MainScene.NavStatus.Gacha);
                
                _gachaUIManager.gameObject.SetActive(true);
            }
        }
    }
    
}


