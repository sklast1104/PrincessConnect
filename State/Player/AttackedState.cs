using System;
using System.Collections;
using Jun.Manage;
using Jun.Utility;
using UnityEngine;

namespace Jun.Stat.Player
{
    public class AttackedState : BaseState
    {
        public AttackedState(PlayerStateMachine machine) : base(machine)
        {
        }

        private float _elapsedTime;
        private float _delay = 0.6f;

        private System.Random rand = new System.Random();
        
        public override void Enter()
        {
            _elapsedTime = 0f;
            
            _machine.SkeletonAnimation.AnimationState.SetAnimation(0, _machine.DataContainer.animMap["Attacked"], false);
            
            if (_machine.PortIndex == 4)
            {
                int index = rand.Next(1, 3);

                if (index == 1)
                {
                    Manager.Sound.Play(Define.Sound.Effect, "105801(pecovoice)/vo_btl_105801 [7]");
                }else if (index == 2)
                {
                    Manager.Sound.Play(Define.Sound.Effect, "105801(pecovoice)/vo_btl_105801 [8]");
                }
                else
                {
                    Manager.Sound.Play(Define.Sound.Effect, "105801(pecovoice)/vo_btl_105801 [9]");
                }
                
                
                
                //_machine.StartCoroutine(PecoEff());
            }
        }

        IEnumerator PecoEff()
        {
            yield return new WaitForSeconds(0.5f);
            
            Debug.Log("Attacked");
            
            Manager.Sound.Play(Define.Sound.Effect, "105801(pecovoice)/vo_btl_105801 [8]");
        }
        
        public override void Tick()
        {
            _elapsedTime += Time.deltaTime;

            if (_elapsedTime > _delay)
            {
                _machine.SwitchState(_machine.StateMap[PlayerStateMachine.States.Idle]);
            }
        }

        public override void Exit()
        {
            
        }
    }
}