using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GachaExitBtn : MonoBehaviour
{
    private Button _button;
    private PickUpUIManager _pickUpUI;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _pickUpUI = FindObjectOfType<PickUpUIManager>(true);
        
        _button.onClick.AddListener((() =>
        {
            _pickUpUI.gameObject.SetActive(false);
        }));
    }
}
