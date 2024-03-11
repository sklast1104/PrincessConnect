using System;
using Jun.Data;
using Jun.Manage.Game;
using Jun.Utility;
using UnityEngine;
using UnityEngine.UI;

namespace Jun.UI.BattleScene
{
    public class PortraitHandler : UI_Base
    {
        [SerializeField]
        private GameObject[] _portraitGos = new GameObject[5];
        
        private GameObject[] _hpObjs = new GameObject[5];
        private GameObject[] _mpObjs = new GameObject[5];
        [SerializeField]
        private GameObject[] _skillFrameObjs = new GameObject[5];
        
        private RosterManager _rosterManager;
        private Character[] Loster;

        private int _maxWidthVal = 157;
        
        enum PortraitGo
        {
            Portrait0,
            Portrait1,
            Portrait2,
            Portrait3,
            Portrait4,
        }

        // 이걸 Start에서 호출해주지 말고 씬 넘어갈 시점에 따로 호출해주는게 좋을듯
        // 일단 테스트용으로 Awake로 두고 개발
        public override void Init()
        {
            _rosterManager = FindObjectOfType<RosterManager>(true);
            Loster = _rosterManager.Loster;
            Bind<GameObject>(typeof(PortraitGo));

            for (int i = 0; i < 5; i++)
            {
                _portraitGos[i] = Get<GameObject>(i);
            }
            
            InitPortraitImages();
            InitHPMPObjs();
        }

        private void Awake()
        {
            Init();
        }

        private void Start()
        {
        
        }

        void InitPortraitImages()
        {
            for (int i = 0; i < 5; i++)
            {
                _portraitGos[i].GetComponent<Image>().sprite = Loster[i].icon;
            }
        }

        void InitHPMPObjs()
        {
            for (int i = 0; i < 5; i++)
            {
                _hpObjs[i] = Util.FindChild(_portraitGos[i], "HP", true);
                _mpObjs[i] = Util.FindChild(_portraitGos[i], "MP", true);
                _skillFrameObjs[i] = Util.FindChild(_portraitGos[i], "SkillReady", true);
            }
        }

        public void SetHp(float percent, int index)
        {
            float width = percent * _maxWidthVal;
            Vector2 vecWidth = _hpObjs[index].GetComponent<RectTransform>().sizeDelta;
            vecWidth.x = width;
            _hpObjs[index].GetComponent<RectTransform>().sizeDelta = vecWidth;
        }

        public void SetMp(float percent, int index)
        {
            float width = percent * _maxWidthVal;
            Vector2 vecWidth = _mpObjs[index].GetComponent<RectTransform>().sizeDelta;
            vecWidth.x = width;
            _mpObjs[index].GetComponent<RectTransform>().sizeDelta = vecWidth;
        }

        public void SetPlusMp(float percent, int index)
        {
            if (percent > 1f) return;
            
            float curPercent = GetCurMpPercent(index);
            
            if (curPercent > 100f) return;

            Vector2 vecWidth = _mpObjs[index].GetComponent<RectTransform>().sizeDelta;
            
            // Debug.Log(percent);
            // Debug.Log(curPercent);
            
            if (curPercent + percent > 1f)
            {
                float width = 1f * _maxWidthVal;
                vecWidth.x = width;
                _mpObjs[index].GetComponent<RectTransform>().sizeDelta = vecWidth;
                
                ActiveSkillFrame(index, true);
            }
            else
            {
                float width = percent * _maxWidthVal;
                vecWidth.x += width;
                _mpObjs[index].GetComponent<RectTransform>().sizeDelta = vecWidth;
            }
        }

        public float GetCurMpPercent(int index)
        {
            Vector2 vecWidth = _mpObjs[index].GetComponent<RectTransform>().sizeDelta;
            float percent = vecWidth.x / _maxWidthVal;

            return percent;
        }

        public void ActiveSkillFrame(int index, bool isActive)
        {
            _skillFrameObjs[index].SetActive(isActive);
        }
    }
}


