using System;
using System.Collections;
using System.Collections.Generic;
using Jun.Manage;
using Jun.Utility;
using UnityEngine;
using UnityEngine.UI;

namespace Jun.UI.BattleScene
{
    public class NextBtnHandler : MonoBehaviour
    {
        private Button _button;
        private Fader _fader;

        private void Awake()
        {
            _button = GetComponent<Button>();
            _fader = FindObjectOfType<Fader>();
            
            _button.onClick.AddListener((() =>
            {
               _fader.BattleToMain();

               StartCoroutine(SceneLoader());
            }));
        }

        IEnumerator SceneLoader()
        {
            yield return new WaitForSeconds(1.5f);
            
            Manager.Scene.LoadScene(Define.Scene.MainScene); 
        }
    }
}


