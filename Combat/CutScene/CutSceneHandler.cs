using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jun.Combat.CutScene
{
    public class CutSceneHandler : MonoBehaviour
    {
        public Action TimLineEndEvt;

        public Action DmgEvent;
        
        private BattleManager _battleManager;

        private void Awake()
        {
            _battleManager = FindObjectOfType<BattleManager>(true);
        }

        public void DamageEvent()
        {
            DmgEvent?.Invoke();
        }

        public void DisActive()
        {
            TimLineEndEvt?.Invoke();
            _battleManager.RestoreMonsterState();
            
            gameObject.SetActive(false);
        }
    }
}


