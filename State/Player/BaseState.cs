using Jun.Scene.Battle;
using UnityEngine;

namespace Jun.Stat.Player
{
    public abstract class BaseState : State
    {
        protected PlayerStateMachine _machine;
        
        public BaseState(PlayerStateMachine machine)
        {
            _machine = machine;
            
        }
        
        
    }
}