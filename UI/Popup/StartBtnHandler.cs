using System.Collections;
using Jun.Manage;
using Jun.UI.Common;
using Jun.UI.Popup;
using Jun.Utility;
using UnityEngine;
using UnityEngine.UI;

public class StartBtnHandler : MonoBehaviour
{
    private Button _button;
    private Fader _fader;
    private LoadingEffect _lEffect;

    private CanvasGroup _popupCg;

    private PostProcessManager _ppManager;
    
    private void Awake()
    {
        _lEffect = FindObjectOfType<LoadingEffect>(true);
        _ppManager = FindObjectOfType<PostProcessManager>();
        _popupCg = FindObjectOfType<DePopupManager>().gameObject.GetComponent<CanvasGroup>();
        _fader = FindObjectOfType<Fader>(true);
        _button = GetComponent<Button>();
        
        _button.onClick.AddListener((() =>
        {
            _ppManager.EnableDof(false);
            _popupCg.alpha = 0;
            StartCoroutine(SceneChangeEffect());
        }));
    }

    IEnumerator SceneChangeEffect()
    {
        _fader.FadeReady();
        
        yield return _fader.SwipeIn(1f);
        
        _lEffect.StartEffect();

        //_fader.gameObject.SetActive(false);
        
        Manager.Scene.LoadScene(Define.Scene.BattleScene);
    }
    
}
