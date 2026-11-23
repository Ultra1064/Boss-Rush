namespace Victor
{
    public class StateMachine
    {
        State currentState;
        public VictorBoss boss; //Change to boss script

        public StateMachine(VictorBoss enemy) //A Constructor in my Unity Project?!
        {
            boss = enemy;
        }

        public void OnUpdate()
        {
            currentState.OnUpdate();
        }

        public void ChangeState(State newState)
        {
            currentState?.OnExit();

            currentState = newState;

            currentState?.OnEnter();
        }

        public State GetState()
        {
            return currentState;
        }
    }
}

