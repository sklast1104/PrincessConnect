using UnityEngine;

namespace Jun.Stat.Player
{
    public class RestartState : BaseState
    {
        public RestartState(PlayerStateMachine machine) : base(machine)
        {
            _startPos = _machine.transform.position - new Vector3(5, 0, 0);
            _destPos = _machine.transform.position;
            _transform = _machine.transform;
            dir = (_destPos - _startPos).normalized;
        }

        private Vector3 _startPos;
        private Vector3 _destPos;
        private Vector3 dir;
        private float speed = 3f;
        private float _elapsedTime = 0f;
        private float _delay = 2f;
        
        private Transform _transform;
        
        public override void Enter()
        {
            _transform.position = _startPos;
            _machine.SkeletonAnimation.AnimationState.SetAnimation(0, _machine.DataContainer.animMap["Move"], true);
            _elapsedTime = 0f;
        }

        public override void Tick()
        {
            _elapsedTime += Time.deltaTime;
            
            Vector3 movement = dir * (speed * Time.deltaTime);
            _machine.transform.position += movement;
            
            if (Vector3.Distance(_transform.position, _destPos) < 0.1f)
            {
                _machine.SwitchState(_machine.StateMap[PlayerStateMachine.States.Idle]);
            }
        }

        public override void Exit()
        {
            
        }
    }
}