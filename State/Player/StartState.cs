using UnityEngine;

namespace Jun.Stat.Player
{
    public class StartState : BaseState
    {
        private Vector3 _startPos;
        private Vector3 _destPos;

        private Vector3 dir;
        
        private float speed = 3f;

        private float _elapsedTime = 0f;
        private float _delay = 2f;

        private bool _firstChecker = true;
        
        private Transform _transform;
        public StartState(PlayerStateMachine _machine) : base(_machine)
        {
            _startPos = _machine.transform.position - new Vector3(5, 0, 0);
            _destPos = _machine.transform.position;

            _transform = _machine.transform;
            
            dir = (_destPos - _startPos).normalized;
        }

        public override void Enter()
        {
            _transform.position = _startPos;
            
            _machine.SkeletonAnimation.AnimationState.SetAnimation(0, _machine.DataContainer.animMap["GameStart"], true);
            
            _elapsedTime = 0f;
        }

        public override void Tick()
        {
            _elapsedTime += Time.deltaTime;

            if (_elapsedTime < _delay && _firstChecker)
            {
                return;
            }
            else
            {
                _firstChecker = false;
            }
            
            Vector3 movement = dir * (speed * Time.deltaTime);
            
            _machine.transform.position += movement;

            if (Vector3.Distance(_transform.position, _destPos) < 0.1f)
            {
                _machine.SwitchState(_machine.StateMap[PlayerStateMachine.States.StandBy]);
            }
            
        }

        public override void Exit()
        {
            
        }
    }
}