using System.Collections;
using Jun.Manage;
using Jun.Utility;
using UnityEngine;
using UnityEngine.UI;

namespace Jun.UI.Title
{
    public class ChangeBtnHandler : MonoBehaviour
    {
        private Button _button;
        private Fader _fader;
        
        private void Awake()
        {
            _button = GetComponent<Button>();
            _fader = FindObjectOfType<Fader>(true);
            
            _button.onClick.AddListener((() =>
            {
                _fader.TitleToMain();

                StartCoroutine(WaitChange());
            }));
        }

        IEnumerator WaitChange()
        {
            yield return new WaitForSeconds(1.5f);
            
            Manager.Scene.LoadScene(Define.Scene.MainScene);
        }
    }
}


