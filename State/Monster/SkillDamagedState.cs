using Jun.Combat;
using UnityEngine;

namespace Jun.Stat.Monster
{
    public class SkillDamagedState : BaseState
    {
        private readonly int _attackedHash = Animator.StringToHash("Attacked");

        private float elapsedTime;
        private float delay;
        
        public SkillDamagedState(MonsterStateMachine machine) : base(machine)
        {
        }

        public override void Enter()
        {
            elapsedTime = 0f;
            delay = 0.6f;
            
            _machine.animator.CrossFadeInFixedTime(_attackedHash, 0f);
            _machine.gameObject.GetComponentInChildren<ColorChanger>().ChangeColorRestor();
        }

        public override void Tick()
        {
            elapsedTime += Time.deltaTime;

            if (elapsedTime > delay)
            {
                _machine.SwitchState(_machine.StateMap[MonsterStateMachine.States.Wait]);
            }
        }

        public override void Exit()
        {
            
        }
    }
}