using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Jun.UI.GachaUI
{
    public class GachaStartBtn : MonoBehaviour
    {
        private Button _button;
        private GachaTimeLineHandler handler;
        private PickUpUIManager _manager;

        private void Awake()
        {
            _button = GetComponent<Button>();
            handler = FindObjectOfType<GachaTimeLineHandler>(true);
            _manager = FindObjectOfType<PickUpUIManager>(true);
            
            _button.onClick.AddListener((() =>
            {
                _manager.gameObject.SetActive(false);
                handler.StartTimeLine();
            }));
        }
    }
}


