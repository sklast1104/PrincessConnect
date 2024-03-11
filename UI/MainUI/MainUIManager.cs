using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jun.UI.MainUI
{
    public class MainUIManager : UI_Base
    {
        private MainCharacterUI chUI;
        
        enum Gameobjects
        {
            Status_Panel,
            Left_Top_Event_Panel,
            Bottom_Button_Panel,
            Void_Sub_Panel,
            Upper_Button_Panel,
        }

        private void Awake()
        {
            Init();
        }
        
        public override void Init()
        {
            chUI = FindObjectOfType<MainCharacterUI>();
            
            Bind<GameObject>(typeof(Gameobjects));
            GameObject statusPanel = Get<GameObject>(0);
        }

        public void FadeIn()
        {
            for (int i = 0; i < 5; i++)
            {
                Get<GameObject>(i).GetComponent<Fadable>().FadeIn();
            }
            
            chUI.FadeIn();
        }

        public void FadeOut()
        {
            for (int i = 0; i < 5; i++)
            {
                Get<GameObject>(i).GetComponent<Fadable>().FadeOut();
            }
            
            chUI.FadeOut();
        }
    }
}


