using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvBackBtnHandler : MonoBehaviour
{
    private Button _btn;

    public GameObject myCanvas;
    public GameObject prevCanvas;
    
    private void Awake()
    {
        _btn = GetComponent<Button>();
        
        _btn.onClick.AddListener((() =>
        {
            myCanvas.SetActive(false);
            prevCanvas.SetActive(true);
        }));
    }
}
