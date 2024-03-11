using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GachaSpecialBtn : MonoBehaviour
{
    private Button btn;
    private GachaCharUI _ui;
    private GachaPrResult _result;
    
    private void Awake()
    {
        btn = GetComponent<Button>();
        _ui = FindObjectOfType<GachaCharUI>(true);
        _result = FindObjectOfType<GachaPrResult>(true);
        
        btn.onClick.AddListener((() =>
        {
            _ui.gameObject.SetActive(false);
            _result.gameObject.SetActive(true);
        }));
    }
    
    
}
