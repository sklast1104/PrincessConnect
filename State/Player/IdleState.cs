using Jun.Combat;
using UnityEngine;

namespace Jun.Stat.Player
{
    public class IdleState : BaseState
    {
        private BattleManager _battle;

        private float elapsedTime = 0f;
        private float delay = 1f;
        
        public IdleState(PlayerStateMachine machine) : base(machine)
        {
            
        }

        public override void Enter()
        {
            _battle = _machine.BattleManager;
            
            _machine.SkeletonAnimation.AnimationState.SetAnimation(0, _machine.DataContainer.animMap["Idle"], true);
            //_machine.SkeletonAnimation.AnimationState.
            
            _battle.OnMove += MoveHandler;
            _battle.OnStop += StopHandler;

            _battle.OnWait += WaitHandler;

            elapsedTime = 0f;
            
            //_machine.SwitchState(_machine.StateMap[PlayerStateMachine.States.Skill]);
        }

        public override void Tick()
        {
            elapsedTime += Time.deltaTime;
        }

        public override void Exit()
        {
            _battle.OnMove -= MoveHandler;
            _battle.OnStop -= StopHandler;
            
            _battle.OnWait -= WaitHandler;
        }

        void WaitHandler()
        {
            _machine.SwitchState(_machine.StateMap[PlayerStateMachine.States.Wait]);
        }        
        
        void MoveHandler()
        {
            _machine.SwitchState(_machine.StateMap[PlayerStateMachine.States.Move]);
        }

        void StopHandler()
        {
            if (elapsedTime > delay)
            {
                _machine.SwitchState(_machine.StateMap[PlayerStateMachine.States.Attack]);
            }
            
        }
    }
}