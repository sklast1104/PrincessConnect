using System.Collections;
using Jun.Combat;
using Jun.Manage;
using Jun.Stat.Monster;
using Jun.UI.BattleScene;
using Jun.Utility;
using Spine;
using UnityEngine;
using AnimationState = Spine.AnimationState;

namespace Jun.Stat.Player
{
    public class AttackState : BaseState
    {
        private AnimatorStateInfo info;
       
        private BattleManager _battle;

        private bool isAttacked = false;

        private System.Random random = new System.Random();
        
        public AttackState(PlayerStateMachine machine) : base(machine)
        {
            _portraitHandler = GameObject.FindObjectOfType<PortraitHandler>(true);
        }

        private PortraitHandler _portraitHandler;
        
        public override void Enter()
        {
            _machine.Health.OnTakeDamage -= _machine.DamageHandler;
            
            _battle = _machine.BattleManager;
            isAttacked = false;
            
            _machine.SkeletonAnimation.AnimationState.SetAnimation(0, _machine.DataContainer.animMap["Attack"], false);
            
            _battle.OnWait += WaitHandler;
            
            // Delayed Attack sef
            //_machine.StartCoroutine(DelayedSoundEff());
            
            // Delayed Char sef
            //4 peco 3 saren 2 kotkoro 1 kyouka 0 kyaru
            if (_machine.PortIndex == 4)
            {
                _machine.StartCoroutine(PecoEff());
            }else if (_machine.PortIndex == 3)
            {
                _machine.StartCoroutine(SarenEff());
            }else if (_machine.PortIndex == 2)
            {
                _machine.StartCoroutine(KotkoroEff());
            }else if (_machine.PortIndex == 1)
            {
                _machine.StartCoroutine(KyoukaEff());
            }
            else
            {
                _machine.StartCoroutine(KyaruEff());
            }
        }

        IEnumerator PecoEff()
        {
            yield return new WaitForSeconds(0.3f);
            
            Manager.Sound.Play(Define.Sound.Effect, "Weapon/se_adv_weapon_sword_impact_02 [1]", 0.5f);

            int rand = random.Next(1, 3);

            if (rand == 1)
            {
                Manager.Sound.Play(Define.Sound.Effect, "105801(pecovoice)/vo_btl_105801 [2]", 0.5f);
            }else if (rand == 2)
            {
                Manager.Sound.Play(Define.Sound.Effect, "105801(pecovoice)/vo_btl_105801 [3]", 0.5f);
            }
            else
            {
                Manager.Sound.Play(Define.Sound.Effect, "105801(pecovoice)/vo_btl_105801 [4]", 0.5f);
            }
        }
        
        IEnumerator SarenEff()
        {
            yield return new WaitForSeconds(0.3f);
            
            Manager.Sound.Play(Define.Sound.Effect, "Weapon/se_adv_weapon_sword_impact_01 [1]", 0.5f);
            
            int rand = random.Next(1, 3);
            
            if (rand == 1)
            {
                Manager.Sound.Play(Define.Sound.Effect, "102811(saren)/vo_btl_102801 [2]", 0.5f);
            }else if (rand == 2)
            {
                Manager.Sound.Play(Define.Sound.Effect, "102811(saren)/vo_btl_102801 [3]", 0.5f);
            }
            else
            {
                Manager.Sound.Play(Define.Sound.Effect, "102811(saren)/vo_btl_102801 [4]", 0.5f);
            }
        }
        
        IEnumerator KotkoroEff()
        {
            yield return new WaitForSeconds(0.3f);
            
            Manager.Sound.Play(Define.Sound.Effect, "Weapon/se_adv_weapon_axe_whiff_01 [1]", 0.5f);
            
            int rand = random.Next(1, 3);
            
            if (rand == 1)
            {
                Manager.Sound.Play(Define.Sound.Effect, "voice(kotkoro)/vo_btl_105901 [2]", 0.5f);
            }else if (rand == 2)
            {
                Manager.Sound.Play(Define.Sound.Effect, "voice(kotkoro)/vo_btl_105901 [3]", 0.5f);
            }
            else
            {
                Manager.Sound.Play(Define.Sound.Effect, "voice(kotkoro)/vo_btl_105901 [4]", 0.5f);
            }
        }
        
        IEnumerator KyoukaEff()
        {
            yield return new WaitForSeconds(0.3f);
            
            Manager.Sound.Play(Define.Sound.Effect, "Weapon/se_adv_weapon_axe_whiff_01 [1]", 0.5f);
            
            int rand = random.Next(1, 3);
            
            if (rand == 1)
            {
                Manager.Sound.Play(Define.Sound.Effect, "103601(kyouka)/vo_btl_103601 [2]", 0.5f);
            }else if (rand == 2)
            {
                Manager.Sound.Play(Define.Sound.Effect, "103601(kyouka)/vo_btl_103601 [3]", 0.5f);
            }
            else
            {
                Manager.Sound.Play(Define.Sound.Effect, "103601(kyouka)/vo_btl_103601 [4]", 0.5f);
            }
        }
        
        IEnumerator KyaruEff()
        {
            yield return new WaitForSeconds(0.3f);
            
            Manager.Sound.Play(Define.Sound.Effect, "Weapon/se_adv_weapon_axe_whiff_01 [1]", 0.5f);
            
            int rand = random.Next(1, 3);
            
            if (rand == 1)
            {
                Manager.Sound.Play(Define.Sound.Effect, "106011(kyaru)/vo_btl_106001 [2]", 0.5f);
            }else if (rand == 2)
            {
                Manager.Sound.Play(Define.Sound.Effect, "106011(kyaru)/vo_btl_106001 [3]", 0.5f);
            }
            else
            {
                Manager.Sound.Play(Define.Sound.Effect, "106011(kyaru)/vo_btl_106001 [4]", 0.5f);
            }
        }
        
        IEnumerator DelayedSoundEff()
        {
            yield return new WaitForSeconds(0.3f);
            
            int rand = random.Next(1, 5);

            if (rand == 1)
            {
                Manager.Sound.Play(Define.Sound.Effect, "Weapon/se_adv_weapon_axe_hit_01 [1]");
            }else if (rand == 2)
            {
                Manager.Sound.Play(Define.Sound.Effect, "Weapon/se_adv_weapon_sword_impact_02 [1]");
            }else if (rand == 3)
            {
                Manager.Sound.Play(Define.Sound.Effect, "Weapon/se_adv_weapon_sword_impact_01 [1]");
            }else if (rand == 4)
            {
                Manager.Sound.Play(Define.Sound.Effect, "Weapon/se_adv_weapon_sword_impact_02 [1]");
            }
            else
            {
                Manager.Sound.Play(Define.Sound.Effect, "Weapon/se_adv_weapon_sword_impact_01 [1]");
            }
        }

        public override void Tick()
        {
            AnimationState state = _machine.SkeletonAnimation.AnimationState;
            TrackEntry curTrack = state.GetCurrent(0);

            if (curTrack.AnimationTime >= 0.4f && !isAttacked)
            {
                GameObject curFrontMon = _battle.FindMinXMonster();
                curFrontMon.GetComponentInChildren<ColorChanger>().ChangeColorRestor();
                Health monHealth = curFrontMon.GetComponent<MonsterStateMachine>().Health;
                DamageUIManager _damageUIManager = curFrontMon.GetComponent<MonsterStateMachine>().DamageUIManager;
                
                monHealth.DealDamage(10);
                _damageUIManager.DamageEffect(21);
                
                _portraitHandler.SetPlusMp(0.2f, _machine.PortIndex);
                
                isAttacked = true;
            }

            if (curTrack.AnimationTime >= 1f)
            {
                _machine.SwitchState(_machine.StateMap[PlayerStateMachine.States.Idle]);
            }
        }

        public override void Exit()
        {
            _machine.Health.OnTakeDamage += _machine.DamageHandler;
            
            _battle.OnWait -= WaitHandler;
        }
        
        void WaitHandler()
        {
            _machine.SwitchState(_machine.StateMap[PlayerStateMachine.States.Wait]);
        }  
    }
}