using System;
using UnityEngine;
using System.Collections.Generic;
using Jun.Combat;
using Jun.Combat.CutScene;
using Jun.Data;
using Jun.Stat.Monster;
using Jun.Utility;
using Spine.Unity;
using UnityEngine.Playables;

namespace Jun.Stat.Player
{
    public class PlayerStateMachine : StateMachine
    {
        public enum States
        {
            Start,
            Restart,
            StandBy,
            Idle,
            Move,
            Attack,
            Attacked,
            Skill,
            Wait,
            Clear,
            Next,
            End,
        }
        
        private Dictionary<States, State> stateMap = new Dictionary<States, State>();
        public Dictionary<States, State> StateMap { get { return stateMap; } }
        
        public SkeletonAnimation SkeletonAnimation { get; private set; }
        
        public BattleManager BattleManager { get; private set; }
        
        [field:SerializeField]
        public float Delay { get; private set; }

        private StageManager _stageManager;
        private SwipeFader _swipeFader;
        
        public AnimDataContainer DataContainer { get; private set; }

        public PlayableDirector _timeline { get; private set; }
        public GameObject _cutSceneContainer { get; private set; }
        public CutSceneHandler _cutSceneHandler { get; private set; }
        
        // 디버그용 나중에 스테이지 기반으로 캐릭터 생성하게되면 없애야함
        [field:SerializeField]
        public Vector3 charClearPos { get; private set; }

        [field:SerializeField]
        public int PortIndex { get; private set; }
        
        private int waveIndex;
        
        public Health Health { get; private set; }

        public DamageUIManager DamageUIManager { get; private set; }
        
        private void Awake()
        {
            stateMap.Add(States.Start, new StartState(this));
            stateMap.Add(States.Restart, new RestartState(this));
            stateMap.Add(States.StandBy, new StandByState(this));
            stateMap.Add(States.Idle, new IdleState(this));
            stateMap.Add(States.Move, new MoveState(this));
            stateMap.Add(States.Attack, new AttackState(this));
            stateMap.Add(States.Attacked, new AttackedState(this));
            stateMap.Add(States.Next, new NextState(this));
            stateMap.Add(States.Wait, new WaitState(this));
            stateMap.Add(States.Skill, new SkillState(this));
            stateMap.Add(States.Clear, new ClearState(this));
            stateMap.Add(States.End, new EndState(this));
            
            BattleManager = GetComponent<BattleManager>();
            _stageManager = FindObjectOfType<StageManager>();
            _swipeFader = FindObjectOfType<SwipeFader>(true);
            SkeletonAnimation = GetComponentInChildren<SkeletonAnimation>(true);
            DataContainer = GetComponent<AnimDataContainer>();
            _timeline = GetComponentInChildren<PlayableDirector>(true);
            _cutSceneContainer = GetComponentInChildren<CutSceneHandler>(true).gameObject;
            _cutSceneHandler = _cutSceneContainer.GetComponent<CutSceneHandler>();
            Health = GetComponentInChildren<Health>();
            DamageUIManager = GetComponentInChildren<DamageUIManager>(true);
            SkeletonAnimation.AnimationState.Data.DefaultMix = 0f;
            
            waveIndex = 0;
        }

        private void Start()
        {
            SwitchState(stateMap[States.Start]);
        }

        private void OnEnable()
        {
            BattleManager.OnAllDie += NextSceneHandler;
            _stageManager.NextStageEvent += StageStartHandler;
            
            Health.OnTakeDamage += DamageHandler;
            Health.OnDie += DieHandler;
        }

        private void OnDisable()
        {
            BattleManager.OnAllDie -= NextSceneHandler;
            _stageManager.NextStageEvent -= StageStartHandler;
            
            Health.OnTakeDamage -= DamageHandler;
            Health.OnDie -= DieHandler;
        }

        private void NextSceneHandler()
        {
            if (waveIndex != 2)
            {
                waveIndex += 1;
                SwitchState(stateMap[States.Next]);
            }
            else
            {
                ClearStageHandler();
            }
        }

        private void ClearStageHandler()
        {
            SwitchState(stateMap[States.Clear]);
        }

        private void StageStartHandler()
        {
            if (waveIndex== 0)
            {
                _swipeFader.EffectEnd();
                SwitchState(stateMap[States.Start]);
            }
            else
            {
                _swipeFader.EffectEnd();
                SwitchState(stateMap[States.Restart]);
            }
        }

        public void SkillStart()
        {
            SwitchState(stateMap[States.Skill]);
        }
        
        public void DamageHandler()
        {
            SwitchState(stateMap[States.Attacked]);
        }
        
        private void DieHandler()
        {
            //SwitchState(StateMap[States.Die]);
        }
    }
}