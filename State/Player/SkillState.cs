using Jun.Combat;
using Jun.Combat.CutScene;
using Jun.Stat.Monster;
using UnityEngine;

namespace Jun.Stat.Player
{
    public class SkillState : BaseState
    {
        private CutSceneUIHandler _uiHandler;
        private CutSceneHandler _cutSceneHandler;
        private BattleManager _battleManager;
        private CharacterHandler _characterHandler;
        
        // MovieDelay
        private float _elapsedTime;
        private float _movideDelay;
        private bool _movieFlag;

        // Monster
        private MonsterStateMachine attackedMonster;
        
        public SkillState(PlayerStateMachine machine) : base(machine)
        {
        }

        public override void Enter()
        {
            if (null == _uiHandler)
                _uiHandler = GameObject.FindObjectOfType<CutSceneUIHandler>(true);
            _battleManager = _machine.BattleManager;
            _cutSceneHandler = _machine._cutSceneHandler;
            _characterHandler = GameObject.FindObjectOfType<CharacterHandler>(true);

            _elapsedTime = 0f;
            _movideDelay = 2f;
            _movieFlag = false;

            _uiHandler.gameObject.SetActive(true);
            _battleManager.InvokeWait();

            _cutSceneHandler.TimLineEndEvt += CutSceneEndTrigger;

            // 몬스터 처리
            GameObject curFrontMon = _battleManager.FindMinXMonster();
            _battleManager.DisableExceptMinX();
            attackedMonster = curFrontMon.GetComponent<MonsterStateMachine>();
            curFrontMon.GetComponent<MonsterStateMachine>().MakeSkillAttackedState();
            
            // 동료 처리
            _characterHandler.DisablePrincessExceptMe(_machine.gameObject);
            
            // 몬스터 피격 이벤트 처리
            _cutSceneHandler.DmgEvent += MakeMonsterAttacked;
        }

        public override void Tick()
        {
            _elapsedTime += Time.deltaTime;

            if (_elapsedTime >= _movideDelay && !_movieFlag)
            {
                _movieFlag = true;
                
                _uiHandler.gameObject.SetActive(false);
                
                _machine._cutSceneContainer.SetActive(true);
                _machine._timeline.Play();
            }

            // 여기서 타임라인 키기
        }

        public override void Exit()
        {
            _cutSceneHandler.TimLineEndEvt -= CutSceneEndTrigger;
            _cutSceneHandler.DmgEvent -= MakeMonsterAttacked;
            
            attackedMonster.MakeMonsterIdle();
            
            // 동료상태 복구
            _characterHandler.RestorePrincess();
        }

        void CutSceneEndTrigger()
        {
            _machine.SwitchState(_machine.StateMap[PlayerStateMachine.States.Idle]);
        }

        void MakeMonsterAttacked()
        {
            attackedMonster.MakeSkillDamagedState();
        }
    }
}