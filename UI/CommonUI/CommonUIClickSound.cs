using System;
using System.Collections;
using System.Collections.Generic;
using Jun.Manage;
using Jun.Utility;
using UnityEngine;
using UnityEngine.UI;

public class CommonUIClickSound : MonoBehaviour
{
    private Button btn;
    
    private void Awake()
    {
        btn = GetComponent<Button>();
        
        btn.onClick.AddListener((() =>
        {
            Manager.Sound.Play(Define.Sound.Effect, "effect/icon_click");
        }));
    }
}
