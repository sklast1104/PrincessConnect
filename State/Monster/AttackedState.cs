using Jun.Combat;
using UnityEngine;

namespace Jun.Stat.Monster
{
    public class AttackedState : BaseState
    {
        private readonly int _attackedHash = Animator.StringToHash("Attacked");
        
        private float elapsedTime;
        private float delay = 0.6f;

        
        
        public AttackedState(MonsterStateMachine machine) : base(machine)
        {
        }

        public override void Enter()
        {
            _machine.attackedCount += 1;
            _machine.animator.CrossFadeInFixedTime(_attackedHash, 0f);
            
            _machine.UI.SetActive(true);

            elapsedTime = 0f;

            _machine._hpController.SetHpVal(_machine.Health.GetPercentage());
            
        }

        public override void Tick()
        {
            elapsedTime += Time.deltaTime;
            
            if (elapsedTime > delay)
            {
                _machine.SwitchState(_machine.StateMap[MonsterStateMachine.States.Idle]);
            }
        }

        public override void Exit()
        {
            _machine.UI.SetActive(false);
        }
    }
}