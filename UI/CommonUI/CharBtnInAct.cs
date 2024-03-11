using System;
using System.Collections;
using System.Collections.Generic;
using Jun.Scene.Main;
using Jun.UI.Common;
using UnityEngine;
using UnityEngine.UI;

public class CharBtnInAct : MonoBehaviour
{
    private Button _btn;
    private MainScene _mainScene;
    private TopNavManager _topNav;

    private void Awake()
    {
        _btn = GetComponent<Button>();
        _mainScene = FindObjectOfType<MainScene>(true);
        _topNav = FindObjectOfType<TopNavManager>(true);
        
        _btn.onClick.AddListener((() =>
        {
            _topNav.gameObject.SetActive(false);
            
            _mainScene.EnableNavBtn(MainScene.NavStatus.Character);
            _mainScene.EnableUICanvas(MainScene.NavStatus.Character);
            
        }));
    }
}
