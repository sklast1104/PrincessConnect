using System;
using System.Collections;
using Spine.Unity;
using UnityEngine;

namespace Jun.Combat
{
    public class ColorChanger : MonoBehaviour
    {
        private SkeletonMecanim _skeletonMecanim;
        private SkeletonAnimation _skeletonAnimation;

        private bool isMonster;
        
        private void Awake()
        {
            _skeletonMecanim = GetComponent<SkeletonMecanim>();
            _skeletonAnimation = GetComponent<SkeletonAnimation>();

            if (_skeletonMecanim != null)
            {
                isMonster = true;
            }
            else
            {
                isMonster = false;
            }
        }

        public void ChangeColorRestor()
        {
            StartCoroutine(WaitChange());
        }

        IEnumerator WaitChange()
        {
            ChangeAttackedColor();
            yield return new WaitForSeconds(0.6f);
            RestoreColor();
        }
        
        public void ChangeAttackedColor()
        {
            if (isMonster)
                _skeletonMecanim.skeleton.SetColor(Color.red);
            else
            {
                _skeletonAnimation.skeleton.SetColor(Color.red);
            }
        }

        public void RestoreColor()
        {
            if (isMonster)
                _skeletonMecanim.skeleton.SetColor(Color.white);
            else 
                _skeletonAnimation.skeleton.SetColor(Color.white);
        }

        private IEnumerator MecanimFadeIn(float time)
        {
            while (_skeletonMecanim.skeleton.A > 0)
            {
                _skeletonMecanim.skeleton.A -= Time.deltaTime / time;
                yield return null;
            }
        }
        
        private IEnumerator AnimFadeIn(float time)
        {
            while (_skeletonAnimation.skeleton.A > 0)
            {
                _skeletonAnimation.skeleton.A -= Time.deltaTime / time;
                yield return null;
            }
        }

        public void AlphaFadeIn(float time)
        {
            if (isMonster)
                StartCoroutine(MecanimFadeIn(time));
            else
                StartCoroutine(AnimFadeIn(time));
        }
    }
}


