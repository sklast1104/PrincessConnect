using DG.Tweening;
using Jun.Data;
using Jun.UI.Popup;
using Jun.Utility;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Jun.UI.QuestMapUI
{
    public class MapIconBtnHanlder : MonoBehaviour
    {
        [SerializeField] private Stage stage;
        
        private Button _button;
        private GameObject _detailPopup;
        private RectTransform _transform;
        private Transform popupTransform;

        private UI_EventHandler _eventHandler;
        private PostProcessManager _ppManager;
        private void Awake()
        {
            _ppManager = FindObjectOfType<PostProcessManager>();
            _eventHandler = GetComponent<UI_EventHandler>();
            _transform = GetComponent<RectTransform>();
            _button = GetComponent<Button>();
            _detailPopup = FindObjectOfType<DePopupManager>(true).gameObject;
            popupTransform = _detailPopup.GetComponent<Transform>();
            
            _button.onClick.AddListener((() =>
            {
                
                //_detailPopup.SetActive(true);
            }));
        }

        private void OnPointerDown(PointerEventData eventData)
        {
            _transform.DOScale(new Vector3(1.1f, 1.1f, 0f), 0.5f);
        }

        private void OnPointerExit(PointerEventData eventData)
        {
            _transform.DOScale(new Vector3(1.2f, 1.2f, 0f), 0.5f);
        }

        private void OnClick(PointerEventData eventData)
        {
            _ppManager.EnableDof(true);
            _detailPopup.SetActive(true);
            popupTransform.DOScale(new Vector3(0f, 0f, 0f), 0.3f).From();
        }
        
        private void OnEnable()
        {
            _eventHandler.OnClickHandler += OnClick;
            _eventHandler.OnPointerDownHandler += OnPointerDown;
            _eventHandler.OnPointerUpHandler += OnPointerExit;
        }

        private void OnDisable()
        {
            _eventHandler.OnClickHandler -= OnClick;
            _eventHandler.OnPointerDownHandler -= OnPointerDown;
            _eventHandler.OnPointerUpHandler -= OnPointerExit;
        }
    }
}