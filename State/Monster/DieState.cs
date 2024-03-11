using Jun.Combat;
using UnityEngine;

namespace Jun.Stat.Monster
{
    public class DieState : BaseState
    {
        private readonly int _attackedHash = Animator.StringToHash("Die");
        private const float _crossFadeDuration = 0f;

        private ColorChanger _changer;

        private float _elapsedTime;
        private float _limitTime;
        
        public DieState(MonsterStateMachine machine) : base(machine)
        {
        }
        
        public override void Enter()
        {
            _machine.animator.CrossFadeInFixedTime(_attackedHash, _crossFadeDuration);
            _changer = _machine.Changer;

            _elapsedTime = 0f;
            _limitTime = 1f;
            
            _changer.AlphaFadeIn(1f);
        }
        
        public override void Tick()
        {
            _elapsedTime += Time.deltaTime;

            if (_elapsedTime > _limitTime)
            {
                _machine.gameObject.SetActive(false);
            }
        }

        public override void Exit()
        {
            
        }
    }
}