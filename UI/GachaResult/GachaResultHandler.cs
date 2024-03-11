using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GachaResultHandler : MonoBehaviour
{
    private Button _button;
    private AllUIHandler _allUIHandler;

    public GameObject gachaNextBtnUI;
    

    private void Awake()
    {
        _button = GetComponent<Button>();
        _allUIHandler = FindObjectOfType<AllUIHandler>(true);

        _button.onClick.AddListener((() =>
        {
            gachaNextBtnUI.SetActive(true);
            //_allUIHandler.gameObject.SetActive(false);
        }));
    }
    
    
}
