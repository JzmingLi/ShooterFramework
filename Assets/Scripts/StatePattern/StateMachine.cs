namespace StatePattern
{
    public abstract class StateMachine
    {
        public IState CurrentState { get; protected set; }

        public void Initialize(IState initialState)
        {
            CurrentState = initialState;
            initialState.Enter();
        }

        public void Transition(IState nextState)
        {
            CurrentState.Exit();
            CurrentState = nextState;
            nextState.Enter();
        }

        public void Update()
        {
            if (CurrentState != null)
            {
                CurrentState.Update();
            }
        }
    }
}
