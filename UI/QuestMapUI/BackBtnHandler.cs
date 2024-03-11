using Jun.UI.QuestUI;
using UnityEngine;
using UnityEngine.UI;

namespace Jun.UI.QuestMapUI
{
    public class BackBtnHandler : MonoBehaviour
    {
        private Button _button;

        private GameObject _questUI;
        private GameObject _questMapUI;
        
        private void Awake()
        {
            _button = GetComponent<Button>();
            _questUI = FindObjectOfType<QuestUIManager>(true).gameObject;
            _questMapUI = FindObjectOfType<QuestMapUIManager>(true).gameObject;
            
            _button.onClick.AddListener((() =>
            {
                _questUI.SetActive(true);
                _questMapUI.SetActive(false);
            }));
        }
    }
}