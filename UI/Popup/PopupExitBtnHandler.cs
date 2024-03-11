using DG.Tweening;
using Jun.Utility;
using UnityEngine;
using UnityEngine.UI;

namespace Jun.UI.Popup
{
    public class PopupExitBtnHandler : MonoBehaviour
    {
        private Button _button;
        private GameObject _popup;

        private PostProcessManager _ppManager;

        private void Awake()
        {
            _ppManager = FindObjectOfType<PostProcessManager>();
            _button = GetComponent<Button>();
            _popup = FindObjectOfType<DePopupManager>().gameObject;
            
            _button.onClick.AddListener((() =>
            {
                _ppManager.EnableDof(false);
                
                _popup.GetComponent<Transform>().DOScale(new Vector2(0f, 0f), 0.2f)
                    .OnComplete((() =>
                    {
                        _popup.SetActive(false);
                        _popup.GetComponent<Transform>().localScale = new Vector3(1f, 1f, 1f);
                    }));
                
                //_popup.SetActive(false);
            }));
        }
    }
}