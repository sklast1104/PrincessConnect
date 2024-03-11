using UnityEngine;


namespace Jun.Stat.Monster
{
    public class WaitState : BaseState
    {
        private readonly int _idleHash = Animator.StringToHash("Idle");
        private const float _crossFadeDutrion = 0f;
        
        public WaitState(MonsterStateMachine machine) : base(machine)
        {
        }
        
        public override void Enter()
        {
            _machine.animator.CrossFadeInFixedTime(_idleHash, _crossFadeDutrion);
        }

        public override void Tick()
        {
            
        }

        public override void Exit()
        {
            
        }
    }
}