using System;
using System.Collections;
using Jun.Combat;
using UnityEngine;
using UnityEngine.UI;

namespace Jun.Utility
{
    public class SwipeFader : MonoBehaviour
    {
        private CanvasGroup _group;
        private Image _image;
        private Material _material;
        private float fadeVal = -1;
        
        private BattleManager _battleManager;
        private StageManager _stageManager;
        
        private void Awake()
        {
            _image = GetComponent<Image>();
            _material = _image.material;
            _group = GetComponent<CanvasGroup>();
        }

        private void Start()
        {
            _material.SetFloat("_Alpha", -1f);
            
            
        }

        private void OnEnable()
        {
            _battleManager = FindObjectOfType<BattleManager>(true);
            _stageManager = FindObjectOfType<StageManager>(true);
            
            _battleManager.OnAllDie += OnDieHandler;
        }

        private void OnDisable()
        {
            _battleManager.OnAllDie -= OnDieHandler;
        }

        void OnDieHandler()
        {
            if (_stageManager.waveIndex != 2)
            {
                StartCoroutine(Waiter());
            }
            else
            {

            }
        }

        private IEnumerator Waiter()
        {
            yield return new WaitForSeconds(4f);
            yield return SwipeIn(0.2f);
        }
        
        public void EffectStart(float delay)
        {
            StartCoroutine(SwipeIn(delay));
        }

        public void EffectEnd()
        {
            _material.SetFloat("_Alpha", -1f);
        }
        
        public IEnumerator SwipeIn(float time)
        {
            fadeVal = -1f;
            _material.SetFloat("_Alpha", fadeVal);
            
            while (fadeVal < 1f)
            {
                fadeVal += Time.deltaTime / time;

                _material.SetFloat("_Alpha", fadeVal);
                yield return null;
            }
        }
    }
}