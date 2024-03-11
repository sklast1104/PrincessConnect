using Jun.Combat;
using Jun.Stat.Player;
using Jun.UI.BattleScene;
using UnityEngine;

namespace Jun.Stat.Monster
{
    public class AttackState : BaseState
    {
        private readonly int _attackHash = Animator.StringToHash("Attack");
        private const float _crossFadeDuration = 0f;
        
        private AnimatorStateInfo info;

        public AttackState(MonsterStateMachine machine) : base(machine)
        {
            _princessChecker = Object.FindObjectOfType<PrincessChecker>(true);
            _portraitHandler = Object.FindObjectOfType<PortraitHandler>(true);
        }

        private PrincessChecker _princessChecker;
        private PortraitHandler _portraitHandler;
        
        private bool _isAttacked = false;
        
        public override void Enter()
        {
            _machine.Health.OnTakeDamage -= _machine.DamageHandler;
            _machine.attackedCount = 0;
            _machine.animator.CrossFadeInFixedTime(_attackHash, _crossFadeDuration);

            _isAttacked = false;
        }

        public override void Tick()
        {
            info = _machine.animator.GetCurrentAnimatorStateInfo(0);

            if (info.normalizedTime >= 0.4f && !_isAttacked)
            {
                _isAttacked = true;
                GameObject frontPrincess = _princessChecker.FindFirstPrincess();
                frontPrincess.GetComponentInChildren<ColorChanger>().ChangeColorRestor();
                Health princessHealth = frontPrincess.GetComponent<PlayerStateMachine>().Health;
                DamageUIManager _damageUIManager = frontPrincess.GetComponent<PlayerStateMachine>().DamageUIManager;
                
                princessHealth.DealDamage(3);
                _damageUIManager.DamageEffect(13);

                float percent = princessHealth.GetPercentage();

                if (percent < 0f) percent = 0f;
                
                _portraitHandler.SetHp(percent, frontPrincess.GetComponent<PlayerStateMachine>().PortIndex);
            }
            
            if (info.normalizedTime >= 1f)
            {
                _machine.SwitchState(_machine.StateMap[MonsterStateMachine.States.Idle]);
            }
        }

        public override void Exit()
        {
            _machine.Health.OnTakeDamage += _machine.DamageHandler;
        }
    }
}