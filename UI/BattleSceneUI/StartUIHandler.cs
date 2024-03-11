using System;
using System.Collections;
using System.Collections.Generic;
using Jun.Manage;
using Jun.Utility;
using UnityEngine;

namespace Jun.UI.BattleScene
{
    public class StartUIHandler : MonoBehaviour
    {
        private void OnEnable()
        {
            Manager.Sound.Play(Define.Sound.Effect, "effect/se_adv_weapon_sword_impact_03 [1]");

            StartCoroutine(DelayedSound());
        }

        IEnumerator DelayedSound()
        {
            yield return new WaitForSeconds(1f);
            
            Manager.Sound.Play(Define.Sound.Effect, "voice(kotkoro)/vo_btl_105901 [23]");
        }
    }
}


