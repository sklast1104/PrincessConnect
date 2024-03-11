namespace Jun.Stat.Monster
{
    public abstract class BaseState : State
    {
        protected MonsterStateMachine _machine;

        public BaseState(MonsterStateMachine machine)
        {
            _machine = machine;
        }
    }
}