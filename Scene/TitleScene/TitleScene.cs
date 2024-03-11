using System;
using Jun.Manage;
using Jun.Utility;
using UnityEngine;

namespace Jun.Scene.Title
{
    public class TitleScene : MonoBehaviour
    {
        private Camera _mainCamera;
        private Fader _fader;
        private SwipeFader _swipeFader;
        
        private void Awake()
        {
            _mainCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
            _fader = FindObjectOfType<Fader>(true);
            _swipeFader = FindObjectOfType<SwipeFader>(true);
            
            Canvas faderCanvas = _fader.transform.parent.gameObject.GetComponent<Canvas>();
            faderCanvas.worldCamera = _mainCamera;
            
            _swipeFader.transform.parent.gameObject.SetActive(false);

            Canvas swipeCanvas = _swipeFader.transform.parent.gameObject.GetComponent<Canvas>();
            swipeCanvas.worldCamera = _mainCamera;
        }

        private void Start()
        {
            Manager.Sound.Play(Define.Sound.Bgm, "MainMenu_Extend", 0.5f);
        }
    }
}