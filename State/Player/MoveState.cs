using Jun.Combat;
using UnityEngine;

namespace Jun.Stat.Player
{
    public class MoveState : BaseState
    {
        private BattleManager _battle;

        private Transform _transform;
        private float _speed;
        private Vector3 _dir;
        
        public MoveState(PlayerStateMachine machine) : base(machine)
        {
            _dir = new Vector3(1, 0, 0);
        }

        public override void Enter()
        {
            _speed = 1f;
            _transform = _machine.transform;
            
            _machine.SkeletonAnimation.AnimationState.SetAnimation(0, _machine.DataContainer.animMap["Move"], true);
            
            
            _battle = _machine.BattleManager;
            _battle.OnStop += StopHandler;
        }

        public override void Tick()
        {
            Vector3 movement = _dir * _speed * Time.deltaTime;

            _transform.position += movement;
        }

        public override void Exit()
        {
            _battle.OnStop -= StopHandler;
        }

        void StopHandler()
        {
           _machine.SwitchState(_machine.StateMap[PlayerStateMachine.States.Idle]);
        }
    }
}