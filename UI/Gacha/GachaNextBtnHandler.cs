using System;
using System.Collections;
using System.Collections.Generic;
using Jun.Utility;
using UnityEngine;
using UnityEngine.UI;

public class GachaNextBtnHandler : MonoBehaviour
{
    private Button _button;
    private GachaBgContainer _container;
    private GachaSpecialUI _gachaSpecialUI;
    private GachaFader _gachaFader;
    private Fader _fader;
    
    private void Awake()
    {
        _button = GetComponent<Button>();
        _container = FindObjectOfType<GachaBgContainer>(true);
        _gachaSpecialUI = FindObjectOfType<GachaSpecialUI>(true);
        _fader = FindObjectOfType<Fader>(true);
        _gachaFader = FindObjectOfType<GachaFader>(true);
        
        _button.onClick.AddListener((() =>
        {
            _gachaFader.StartFade();

            StartCoroutine(DelayedActive());
        }));
    }

    IEnumerator DelayedActive()
    {
        yield return new WaitForSeconds(1.8f);
        _container.gameObject.SetActive(false);
        _gachaSpecialUI.gameObject.SetActive(true);
        _gachaSpecialUI.PlayVideo();
    }
}
