using System;
using System.Collections;
using Jun.UI.Common;
using Jun.UI.QuestMapUI;
using Jun.Utility;
using UnityEngine;
using UnityEngine.UI;

namespace Jun.UI.QuestUI
{
    public class MainQuestBtn : MonoBehaviour
    {
        private Button _button;
        private Fader _fader;
        private LoadingEffect _loadingEffect;

        private GameObject _questUI;
        private GameObject _mapUI;

        private void OnEnable()
        {
            if (_fader == null)
            {
                _fader = FindObjectOfType<Fader>(true);
            }
            _fader.swipeEnd += OnSwipeEnd;
        }

        private void OnDisable()
        {
            _fader.swipeEnd -= OnSwipeEnd;
        }

        private void OnSwipeEnd()
        {
            _questUI.SetActive(false);
        }

        private void Awake()
        {
            _button = GetComponent<Button>();
            _fader = FindObjectOfType<Fader>(true);
            _loadingEffect = FindObjectOfType<LoadingEffect>(true);

            _questUI = FindObjectOfType<QuestUIManager>(true).gameObject;
            _mapUI = FindObjectOfType<QuestMapUIManager>(true).gameObject;
            
            _button.onClick.AddListener((() =>
            {
                StartCoroutine(QuestFadeInOut());
                _loadingEffect.StartEffect();
            }));
        }
        
        private IEnumerator QuestFadeInOut()
        {
            _fader.FadeReady();
            yield return _fader.FadeOut(0.5f);
            
            _mapUI.SetActive(true);
            
            yield return new WaitForSeconds(2f);
            _loadingEffect.gameObject.SetActive(false);
            yield return _fader.SwipeOut(1f);
            
            // MyPageUI 꺼주고 MapUI 켜주고
            
            //_mapUI.SetActive(true);
        }
    }
}


