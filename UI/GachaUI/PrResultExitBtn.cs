using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrResultExitBtn : MonoBehaviour
{
    private Button _button;
    private GachaPrResult _prResult;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _prResult = FindObjectOfType<GachaPrResult>(true);
        
        _button.onClick.AddListener((() =>
        {
            _prResult.gameObject.SetActive(false);
        }));
    }
}
