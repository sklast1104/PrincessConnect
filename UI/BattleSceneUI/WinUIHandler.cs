using System;
using System.Collections;
using DG.Tweening;
using Jun.Manage;
using Jun.Utility;
using UnityEngine;

namespace Jun.UI.BattleScene
{
    
    
    public class WinUIHandler : MonoBehaviour
    {
        [SerializeField] private GameObject _decoObj;

        public void StartAnimation()
        {
            _decoObj.SetActive(false);
            transform.DOMove(new Vector3(0, 1.1f, 0), 0.5f).SetRelative();
        }

        private void OnEnable()
        {
            Manager.Sound.Play(Define.Sound.Effect, "battle_result/se_battle [123]");
            Manager.Sound.Play(Define.Sound.Bgm, "Win_Bgm");

            StartCoroutine(DelayedPecoSound());
        }

        IEnumerator DelayedPecoSound()
        {
            yield return new WaitForSeconds(1f);

            Manager.Sound.Play(Define.Sound.Effect, "105801(pecovoice)/vo_btl_105801 [26]");
        }
    }
}


