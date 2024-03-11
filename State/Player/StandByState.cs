using UnityEngine;

namespace Jun.Stat.Player
{
    public class StandByState : BaseState
    {
        private float delayTime = 2f;
        private float elapsedTime = 0f;
        
        public StandByState(PlayerStateMachine machine) : base(machine)
        {
        }

        public override void Enter()
        {
            _machine.SkeletonAnimation.AnimationState.SetAnimation(0, _machine.DataContainer.animMap["StandBy"], false);
            delayTime += _machine.Delay;
            elapsedTime = 0f;
        }

        public override void Tick()
        {
            elapsedTime += Time.deltaTime;

            if (elapsedTime > delayTime)
            {
                _machine.SwitchState(_machine.StateMap[PlayerStateMachine.States.Idle]);
            }
        }

        public override void Exit()
        {
            
        }
    }
}