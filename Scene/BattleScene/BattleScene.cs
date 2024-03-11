using System;
using System.Collections;
using Jun.Combat;
using Jun.Manage;
using Jun.Utility;
using UnityEngine;

namespace Jun.Scene.Battle
{
    public class BattleScene : BaseScene
    {
        private Fader _fader;
        private SwipeFader _swipeFader;
        private Camera _mainCamera;
        
        private void Awake()
        {
            _mainCamera = GameObject.FindWithTag("MainCamera").GetComponent<UnityEngine.Camera>();
            _fader = FindObjectOfType<Fader>();
            _swipeFader = FindObjectOfType<SwipeFader>(true);
            
            Canvas faderCanvas = _fader.transform.parent.gameObject.GetComponent<Canvas>();
            faderCanvas.worldCamera = _mainCamera;
            
            _swipeFader.transform.parent.gameObject.SetActive(true);

            Canvas swipeCanvas = _swipeFader.transform.parent.gameObject.GetComponent<Canvas>();
            swipeCanvas.worldCamera = _mainCamera;
            
            Init();
        }

        private void Start()
        {
            if (_fader != null)
            {
                StartCoroutine(OpenSceneEffect());
            }
            
            BattleManager[] managers = FindObjectsOfType<BattleManager>();

            for (int i = 0; i < managers.Length; i++)
            {
                managers[i].AllDieChecked = true;
            }
        }

        private IEnumerator OpenSceneEffect()
        {
            yield return new WaitForSeconds(2f);
            _fader.TurnOffLoadingEff();
            yield return _fader.FadeIn(1f);
        }

        protected override void Init()
        {
            base.Init();

            SceneType = Define.Scene.BattleScene;
            
            //Manager.Sound.Play(Define.Sound.Bgm, "bgm_M36");
        }

        public override void Clear()
        {
            
        }

        private void OnEnable()
        {
            Manager.Sound.Play(Define.Sound.Bgm, "Battle_Theme");
        }
    }
}


