using System.Collections;
using Jun.MyCamera;
using Jun.UI.BattleScene;
using UnityEngine;

namespace Jun.Stat.Player
{
    public class ClearState : BaseState
    {
        public ClearState(PlayerStateMachine machine) : base(machine)
        {
            _expUIHandler = Object.FindObjectOfType<ExpUIHandler>(true);
        }

        private ExpUIHandler _expUIHandler;
        
        public override void Enter()
        {
            // Idle로 잠시 대기한 후에 승리모션으로
            _machine.SkeletonAnimation.AnimationState.SetAnimation(0, _machine.DataContainer.animMap["Idle"], true);

            //Debug.Log("Start Clear State");
            _machine.StartCoroutine(DelayedSetPos());

            _expUIHandler.EndEvent += ToEndState;
        }

        public override void Tick()
        {

        }

        public override void Exit()
        {
            _expUIHandler.EndEvent -= ToEndState;
        }

        private IEnumerator DelayedSetPos()
        {
            yield return new WaitForSeconds(1.2f);
            
            _machine.transform.position = _machine.charClearPos;
            
            yield return new WaitForSeconds(0.8f);
            _machine.SkeletonAnimation.AnimationState.SetAnimation(0, _machine.DataContainer.animMap["JoyResult"], false);
        }

        void ToEndState()
        {
            _machine.SwitchState(_machine.StateMap[PlayerStateMachine.States.End]);
        }
    }
}