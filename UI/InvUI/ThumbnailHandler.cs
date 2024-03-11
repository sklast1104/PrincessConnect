using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThumbnailHandler : MonoBehaviour
{
    private Button btn;

    public GameObject myCanvas;
    public GameObject nextCanvas;
    
    private void Awake()
    {
        btn = GetComponent<Button>();
        
        btn.onClick.AddListener((() =>
        {
            nextCanvas.SetActive(true);
            myCanvas.SetActive(false);
        }));
    }
}
