using UnityEngine;

namespace Jun.Stat
{
    public class StateMachine : MonoBehaviour
    {
        private State currentState;

        public void SwitchState(State newState)
        {
            currentState?.Exit();
            currentState = newState;
            currentState?.Enter();
        }
    
        private void Update()
        {
            currentState?.Tick();
        }

        private void FixedUpdate()
        {
            currentState?.FixedUpdate();
        }

        private void LateUpdate()
        {
            currentState?.LateUpdate();
        }
    }
}


