using System;
using System.Collections;
using Jun.Manage;
using Jun.UI.Common;
using UnityEngine;
using UnityEngine.UI;

namespace Jun.Utility
{
    public class Fader : MonoBehaviour
    {
        private CanvasGroup _group;
        private Image _image;
        private Material _material;
        private float fadeVal = 0;

        public Action swipeEnd;

        private GameObject _loadingEffGo;
        private GameObject _comicPlate;
        private LoadingEffect _effect;
        
        private void Awake()
        {
            _image = GetComponent<Image>();
            _material = _image.material;
            _group = GetComponent<CanvasGroup>();
            _loadingEffGo = FindObjectOfType<LoadingEffect>().gameObject;
            _comicPlate = transform.GetChild(1).gameObject;
            _effect = _loadingEffGo.GetComponent<LoadingEffect>();
        }
        
        public void TurnOffLoadingEff()
        {
            _loadingEffGo.gameObject.SetActive(false);
        }

        public void BattleToMain()
        {
            FadeReady();

            StartCoroutine(BattleToMainEffect());
        }

        public void TitleToMain()
        {
            FadeReady();

            StartCoroutine(TitleToMainEffect());
        }

        public void FadeOutIn()
        {
            FadeReady();
            _comicPlate.gameObject.SetActive(false);
            StartCoroutine(FadeIn(0.4f));
        }

        IEnumerator TitleToMainEffect()
        {
            _comicPlate.SetActive(true);
            yield return FadeOut(0.5f);
            StartAlphabetEffect();

            yield return new WaitForSeconds(2f);
            TurnOffLoadingEff();
            _comicPlate.SetActive(false);
            
            yield return FadeIn(1f);
        }
        
        IEnumerator BattleToMainEffect()
        {
            yield return FadeOut(0.5f);
            StartAlphabetEffect();

            yield return new WaitForSeconds(2f);
            TurnOffLoadingEff();
            yield return SwipeOut(1f);
        }
        
        public void StartAlphabetEffect()
        {
            _effect.StartEffect();
        }
        
        public void FadeReady()
        {
            gameObject.SetActive(true);
            _loadingEffGo.SetActive(true);
        }

        public void FadeOutEffect(float time)
        {
            StartCoroutine(FadeOut(time));
        }
        
        public IEnumerator SwipeIn(float time)
        {
            fadeVal = 0.75f;
            _material.SetFloat("_FadeValue", fadeVal);
            _group.alpha = 1f;

            while (fadeVal > 0f)
            {
                fadeVal -= Time.deltaTime / time;
                _material.SetFloat("_FadeValue", fadeVal);
                yield return null;
            }
            
            //gameObject.SetActive(false);
        }
        
        public IEnumerator SwipeOut(float time)
        {
            fadeVal = 0f;
            _material.SetFloat("_FadeValue", fadeVal);
            
            while (fadeVal < 0.75f)
            {
                fadeVal += Time.deltaTime / time;
                _material.SetFloat("_FadeValue", fadeVal);
                yield return null;
            }

            gameObject.SetActive(false);
            _material.SetFloat("_FadeValue", 0f);
            
            swipeEnd?.Invoke();
        }
        
        public IEnumerator FadeOutIn(float delay)
        {
            yield return FadeOut(delay);
            yield return FadeIn(delay);
        }
        
        public IEnumerator FadeOut(float time)
        {
            _group.alpha = 0;
            
            while (_group.alpha < 1)
            {
                _group.alpha += Time.deltaTime / time;

                yield return null;
            }
        }

        public IEnumerator FadeIn(float time)
        {
            _group.alpha = 1;
            
            while (_group.alpha > 0)
            {
                _group.alpha -= Time.deltaTime / time;
                yield return null;
            }
        }
    }
}