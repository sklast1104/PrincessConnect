using Jun.Scene.Main;
using Jun.UI.MainUI;
using Jun.UI.QuestUI;
using UnityEngine;
using UnityEngine.UI;

namespace Jun.UI.Common
{
    public class MyPageBtn : MonoBehaviour
    {
        private Button button;
        private MainUIManager mainUIManager;
        private QuestUIManager _questUIManager;
        private MainScene _mainScene;
        
        private GameObject _topNavGO;

        private void Awake()
        {
            button = GetComponent<Button>();
            mainUIManager = FindObjectOfType<MainUIManager>(true);
            _questUIManager = FindObjectOfType<QuestUIManager>(true);
            _mainScene = FindObjectOfType<MainScene>();
            _topNavGO = FindObjectOfType<TopNavManager>(true).gameObject;

            button.onClick.AddListener(OnBtnClicked);
        }

        void OnBtnClicked()
        {
            _mainScene.StatusChecker[MainScene.NavStatus.MyPage] = false;
            
            if (false == _mainScene.StatusChecker[MainScene.NavStatus.MyPage])
            {
                _topNavGO.SetActive(false);
                
                _mainScene.EnableNavBtn(MainScene.NavStatus.MyPage);
                
                //_questUIManager.FadeOut();
                _mainScene.EnableUICanvas(MainScene.NavStatus.MyPage);
                //mainUIManager.FadeIn();
                
                gameObject.SetActive(false);
            }
        }
    }
}


