using Unity.VisualScripting;
using UnityEngine;

namespace Jun.Stat.Monster
{
    public class StandByState : BaseState
    {
        private readonly int standbyHash = Animator.StringToHash("StandBy");
        private const float crossFadeDuration = 0.0f;

        private float elapsedTime = 0f;
        
        public StandByState(MonsterStateMachine machine) : base(machine)
        {
        }

        public override void Enter()
        {
            // _machine.Health.OnTakeDamage += TakeDamageHandler;
            
            _machine.animator.CrossFadeInFixedTime(standbyHash, crossFadeDuration);
            elapsedTime = 0f;
        }

        public override void Tick()
        {
            elapsedTime += Time.deltaTime;

            if (elapsedTime > _machine.delay)
            {
                _machine.SwitchState(_machine.StateMap[MonsterStateMachine.States.Idle]);
            }
        }

        public override void Exit()
        {
            // _machine.Health.OnTakeDamage -= TakeDamageHandler;
        }
        
        // void TakeDamageHandler()
        // {
        //     _machine.SwitchState(_machine.StateMap[MonsterStateMachine.States.Attacked]);
        // }
    }
}