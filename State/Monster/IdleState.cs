using Jun.Combat;
using UnityEngine;

namespace Jun.Stat.Monster
{
    public class IdleState : BaseState
    {
        private readonly int _idleHash = Animator.StringToHash("Idle");
        private const float _crossFadeDutrion = 0f;

        public float _elapsedTime = 0f;
        private float _delay = 2f;
        
        public IdleState(MonsterStateMachine machine) : base(machine)
        {
            
        }

        public override void Enter()
        {
            // _machine.Health.OnTakeDamage += TakeDamageHandler;
            _machine.animator.CrossFadeInFixedTime(_idleHash, _crossFadeDutrion);
            _elapsedTime = 0f;
        }

        public override void Tick()
        {
            _elapsedTime += Time.deltaTime;

            AttackHandler();
        }

        public override void Exit()
        {
            // _machine.Health.OnTakeDamage -= TakeDamageHandler;
            _elapsedTime = 0f;
        }

        void AttackHandler()
        {
            if (_elapsedTime > _delay - (_delay * 0.1f * _machine.attackedCount))
            {
                _machine.SwitchState(_machine.StateMap[MonsterStateMachine.States.Attack]);
            }
        }

        // void TakeDamageHandler()
        // {
        //     _machine.SwitchState(_machine.StateMap[MonsterStateMachine.States.Attacked]);
        // }
    }
}