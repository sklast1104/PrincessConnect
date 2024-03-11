using System;
using UnityEngine;
using UnityEngine.UI;

namespace Jun.UI.GachaUI
{
    public class GachaBtnHandler : UI_Base
    {
        private Button _button;
        private PickUpUIManager _pickUpUI;

        private void Awake()
        {
            Init();
        }

        public override void Init()
        {
            _button = GetComponent<Button>();
            _pickUpUI = FindObjectOfType<PickUpUIManager>(true);
            
            _button.onClick.AddListener((() =>
            {
                _pickUpUI.gameObject.SetActive(true);
            }));
        }
    }
}


