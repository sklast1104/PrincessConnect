using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThumbNailClickHandler : MonoBehaviour
{
    public GameObject myCanvas;
    public GameObject InvCanvas;

    private Button _btn;
    
    private void Awake()
    {
        _btn = GetComponent<Button>();
        
        _btn.onClick.AddListener((() =>
        {
            myCanvas.SetActive(false);
            InvCanvas.SetActive(true);
        }));
    }
}
