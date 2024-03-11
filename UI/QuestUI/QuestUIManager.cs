using System;
using System.Collections;
using System.Collections.Generic;
using Jun.Manage;
using Jun.Utility;
using UnityEngine;

namespace Jun.UI.QuestUI
{
    public class QuestUIManager : UI_Base
    {
        private Fadable myEffect;
        
        private void Awake()
        {
            Init();
        }

        public override void Init()
        {
            myEffect = GetComponent<Fadable>();
        }

        public void FadeIn()
        {
            myEffect.FadeIn();
        }

        public void FadeOut()
        {
            myEffect.FadeOut();
        }

        private void OnEnable()
        {
            Manager.Sound.Play(Define.Sound.Bgm, "bgm_M36");
        }
    }
}


