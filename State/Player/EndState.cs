using UnityEngine;

namespace Jun.Stat.Player
{
    public class EndState : BaseState
    {
        private Transform _transform;
        private float _speed;
        private Vector3 _dir;

        private float _elapsedTime;
        private float _duringTime;
        
        public EndState(PlayerStateMachine machine) : base(machine)
        {
        }

        public override void Enter()
        {
            _elapsedTime = 0f;
            _duringTime = 2f;
            
            _speed = 10f;
            _transform = _machine.transform;
            _dir = new Vector3(1, 0, 0);

            _machine.SkeletonAnimation.AnimationState.SetAnimation(0, _machine.DataContainer.animMap["Move"], true);
        }

        public override void Tick()
        {
            _elapsedTime = Time.deltaTime;

            if (_elapsedTime < _duringTime)
            {
                Vector3 movement = _dir * _speed * Time.deltaTime;

                _transform.position += movement;
            }
        }

        public override void Exit()
        {
           
        }
    }
}