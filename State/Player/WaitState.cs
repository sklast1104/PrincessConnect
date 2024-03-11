using Jun.Combat;

namespace Jun.Stat.Player
{
    public class WaitState : BaseState
    {
        private BattleManager _battleManager;
        
        
        public WaitState(PlayerStateMachine machine) : base(machine)
        {
        }

        public override void Enter()
        {
            _machine.SkeletonAnimation.AnimationState.SetAnimation(0, _machine.DataContainer.animMap["Idle"], true);
            _battleManager = _machine.BattleManager;

            _battleManager.OnSkillEnd += OnSkillEndCallBack;
        }

        public override void Tick()
        {
            
        }

        public override void Exit()
        {
            _battleManager.OnSkillEnd -= OnSkillEndCallBack;
        }

        void OnSkillEndCallBack()
        {
            _machine.SwitchState(_machine.StateMap[PlayerStateMachine.States.Idle]);
        }
    }
}