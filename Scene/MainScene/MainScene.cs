using System;
using System.Collections.Generic;
using DG.Tweening;
using Jun.Manage;
using Jun.UI.Common;
using Jun.UI.GachaUI;
using Jun.UI.MainUI;
using Jun.UI.QuestUI;
using Jun.Utility;
using UnityEngine;

namespace Jun.Scene.Main
{
    public class MainScene : BaseScene
    {
        public enum NavStatus
        {
            MyPage,
            Character,
            Quest,
            QuestMap,
            Gacha,
        }
        
        public Dictionary<NavStatus, bool> StatusChecker { private set; get; }
        public Dictionary<NavStatus, GameObject> InActiveBtnMap { private set; get; }
        public Dictionary<NavStatus, GameObject> ActiveBtnMap { private set; get; }
        
        public Dictionary<NavStatus, GameObject> UICanvasMap { private set; get; }

        private Fader _fader;
        private SwipeFader _swipeFader;
        private Camera _mainCamera;
        
        private void Awake()
        {
            _mainCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
            _fader = FindObjectOfType<Fader>();
            _swipeFader = FindObjectOfType<SwipeFader>(true);
            
            Canvas faderCanvas = _fader.transform.parent.gameObject.GetComponent<Canvas>();
            faderCanvas.worldCamera = _mainCamera;
            
            _swipeFader.transform.parent.gameObject.SetActive(false);

            Canvas swipeCanvas = _swipeFader.transform.parent.gameObject.GetComponent<Canvas>();
            swipeCanvas.worldCamera = _mainCamera;
            
            DOTween.Init();
            StatusChecker = new Dictionary<NavStatus, bool>();
            StatusChecker[NavStatus.MyPage] = true;
            StatusChecker[NavStatus.Quest] = false;
            StatusChecker[NavStatus.QuestMap] = false;
            StatusChecker[NavStatus.Gacha] = false;
            StatusChecker[NavStatus.Character] = false;

            InActiveBtnMap = new Dictionary<NavStatus, GameObject>();
            InActiveBtnMap[NavStatus.MyPage] = FindObjectOfType<MyPageBtn>(true).gameObject;
            InActiveBtnMap[NavStatus.Quest] = FindObjectOfType<QuestBtn>(true).gameObject;
            InActiveBtnMap[NavStatus.Gacha] = FindObjectOfType<GachBtnInAct>(true).gameObject;
            InActiveBtnMap[NavStatus.Character] = FindObjectOfType<CharBtnInAct>(true).gameObject;
            
            ActiveBtnMap = new Dictionary<NavStatus, GameObject>();
            ActiveBtnMap[NavStatus.MyPage] = FindObjectOfType<MyPageBtnAct>(true).gameObject;
            ActiveBtnMap[NavStatus.Quest] = FindObjectOfType<QuestBtnAct>(true).gameObject;
            ActiveBtnMap[NavStatus.Gacha] = FindObjectOfType<GachaBtnAct>(true).gameObject;
            ActiveBtnMap[NavStatus.Character] = FindObjectOfType<CharBtnAct>(true).gameObject;

            UICanvasMap = new Dictionary<NavStatus, GameObject>();
            UICanvasMap[NavStatus.MyPage] = FindObjectOfType<MainUIManager>(true).gameObject;
            UICanvasMap[NavStatus.Quest] = FindObjectOfType<QuestUIManager>(true).gameObject;
            UICanvasMap[NavStatus.Gacha] = FindObjectOfType<GachaUIManager>(true).gameObject;
            UICanvasMap[NavStatus.Character] = FindObjectOfType<CharUICanvas>(true).gameObject;
        }
        

        public void EnableNavBtn(NavStatus status)
        {
            foreach (var keyVal in ActiveBtnMap)
            {
                ActiveBtnMap[keyVal.Key].SetActive(false);
            }

            foreach (var keyVal in InActiveBtnMap)
            {
                InActiveBtnMap[keyVal.Key].SetActive(true);
            }
            
            InActiveBtnMap[status].SetActive(false);
            ActiveBtnMap[status].SetActive(true);
        }

        public void EnableUICanvas(NavStatus status)
        {
            foreach (var keyVal in ActiveBtnMap)
            {
                UICanvasMap[keyVal.Key].SetActive(false);
            }
            
            UICanvasMap[status].SetActive(true);
        }
        
        public void EnableNavStatus(NavStatus status)
        {
            foreach (var keyVal in StatusChecker)
            {
                StatusChecker[keyVal.Key] = false;
            }

            StatusChecker[status] = true;
        }

        void Start()
        {
            Init();
        }

        protected override void Init()
        {
            base.Init();

            SceneType = Define.Scene.MainScene;
            
            Manager.Sound.Play(Define.Sound.Bgm, "bgm_M36", 0.5f);
        }

        public override void Clear()
        {
            
        }
    } 
}


