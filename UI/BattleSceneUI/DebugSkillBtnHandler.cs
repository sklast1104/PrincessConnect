using System;
using System.Collections;
using Jun.Manage;
using Jun.Stat.Player;
using Jun.Utility;
using UnityEngine;

namespace Jun.UI.BattleScene
{
    public class DebugSkillBtnHandler : MonoBehaviour
    {
        public PlayerStateMachine pecorinne;
        private PortraitHandler _portraitHandler;

        private void Awake()
        {
            _portraitHandler = FindObjectOfType<PortraitHandler>(true);
        }

        public void UseSkill()
        {
            _portraitHandler.SetMp(0f, 4);
            _portraitHandler.ActiveSkillFrame(4, false);
            pecorinne.SkillStart();

            StartCoroutine(DealyedSound());
        }

        IEnumerator DealyedSound()
        {
            yield return new WaitForSeconds(0.1f);
            
            Manager.Sound.Play(Define.Sound.Effect, "105801(pecovoice)/vo_btl_105801 [5]");
        }
    }
}