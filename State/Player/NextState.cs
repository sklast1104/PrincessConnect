using UnityEngine;

namespace Jun.Stat.Player
{
    public class NextState : BaseState
    {
        private Transform _transform;
        private float _speed;
        private Vector3 _dir;

        private float _elapsedTime;
        private float _delay;

        private bool _motionFlag;

        public NextState(PlayerStateMachine machine) : base(machine)
        {
        }

        public override void Enter()
        {
            _elapsedTime = 0f;
            _delay = 2f;
            _motionFlag = true;
            
            _machine.SkeletonAnimation.AnimationState.SetAnimation(0, _machine.DataContainer.animMap["Idle"], true);
            
            _speed = 4f;
            _transform = _machine.transform;
            _dir = new Vector3(1, 0, 0);
        }

        public override void Tick()
        {
            _elapsedTime += Time.deltaTime;

            if (_elapsedTime > _delay)
            {
                if (_motionFlag)
                {
                    _motionFlag = false;
                    _machine.SkeletonAnimation.AnimationState.SetAnimation(0, _machine.DataContainer.animMap["Move"], true);
                }
                
                Vector3 movement = _dir * _speed * Time.deltaTime;

                _transform.position += movement;
            }
            
        }

        public override void Exit()
        {
            
        }
    }
}