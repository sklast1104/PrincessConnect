using System;
using UnityEngine;
using System.Collections.Generic;
using Jun.Combat;
using Jun.Stat.Player;

namespace Jun.Stat.Monster
{
    public class MonsterStateMachine : StateMachine
    {
        public enum States
        {
            Start,
            Restart,
            StandBy,
            Idle,
            Attack,
            Attacked,
            Wait,
            SkillDamaged,
            Die,
        }
        
        private Dictionary<States, State> stateMap = new Dictionary<States, State>();
        public Dictionary<States, State> StateMap { get { return stateMap; } }
        public Animator animator { get; private set; }
        public Health Health { get; private set; }
        
        public ColorChanger Changer { get; private set; }
        
        public GameObject UI { get; private set; }
        public HpUIController _hpController { get; private set; }

        public int attackedCount;
        
        [field:SerializeField] public float delay { get; private set; }
        private StageManager _stageManager;
        public DamageUIManager DamageUIManager { get; private set; }

        private void Awake()
        {
            attackedCount = 0;
            
            stateMap.Add(States.Start, new StartState(this));
            stateMap.Add(States.StandBy, new StandByState(this));
            stateMap.Add(States.Idle, new IdleState(this));
            stateMap.Add(States.Attack, new AttackState(this));
            stateMap.Add(States.Attacked, new AttackedState(this));
            StateMap.Add(States.Die, new DieState(this));
            StateMap.Add(States.Wait, new WaitState(this));
            StateMap.Add(States.SkillDamaged, new SkillDamagedState(this));
            StateMap.Add(States.Restart, new ReStartState(this));
            animator = GetComponentInChildren<Animator>();
            Health = GetComponentInChildren<Health>();
            Changer = GetComponentInChildren<ColorChanger>();
            UI = GetComponentInChildren<HpUIController>(true).transform.parent.gameObject;
            _hpController = GetComponentInChildren<HpUIController>(true);
            _stageManager = FindObjectOfType<StageManager>(true);
            DamageUIManager = GetComponentInChildren<DamageUIManager>(true);
        }

        private void Start()
        {
            if (_stageManager.waveIndex == 0)
            {
                SwitchState(stateMap[States.Start]);
            }
            else
            {
                SwitchState(stateMap[States.Restart]);
            }
        }

        private void OnEnable()
        {
            Health.OnTakeDamage += DamageHandler;
            Health.OnDie += DieHandler;
        }

        private void OnDisable()
        {
            Health.OnTakeDamage -= DamageHandler;
            Health.OnDie -= DieHandler;
        }

        public void DamageHandler()
        {
            SwitchState(stateMap[States.Attacked]);
        }
        
        private void DieHandler()
        {
            SwitchState(StateMap[States.Die]);
        }

        public void MakeSkillAttackedState()
        {
            SwitchState(stateMap[States.Wait]);
        }

        public void MakeSkillDamagedState()
        {
            SwitchState(stateMap[States.SkillDamaged]);
        }

        public void MakeMonsterIdle()
        {
            SwitchState(stateMap[States.Idle]);
        }
    }
}


