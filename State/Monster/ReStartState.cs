using UnityEngine;

namespace Jun.Stat.Monster
{
    public class ReStartState : BaseState
    {
        public ReStartState(MonsterStateMachine machine) : base(machine)
        {
            _startPos = _machine.transform.position + new Vector3(5, 0, 0);
            _destPos = _machine.transform.position;
            
            _transform = _machine.transform;
            
            _dir = (_destPos - _startPos).normalized;
        }

        private Vector3 _startPos;
        private Vector3 _destPos;
        private Vector3 _dir;
        private float _speed = 3f;

        private Transform _transform;

        private readonly int _runHash = Animator.StringToHash("RunGS");
        private const float _crossFadeDuration = 0f;
        
        private float _elapsedTime = 0f;

        public override void Enter()
        {
            _transform.position = _startPos;
            _machine.animator.CrossFadeInFixedTime(_runHash, _crossFadeDuration);

            _elapsedTime = 0f;
        }

        public override void Tick()
        {
            _elapsedTime += Time.deltaTime;
            
            Vector3 movement = _dir * (_speed * Time.deltaTime);
            
            if (Vector3.Distance(_transform.position, _destPos) < 0.1f)
            {
                _machine.SwitchState(_machine.StateMap[MonsterStateMachine.States.Idle]);
            }
            
            _machine.transform.position += movement;
        }

        public override void Exit()
        {
            
        }
    }
}