namespace Victor
{
    public class StunnedState : State
    {
        public StunnedState(StateMachine machine) : base(machine)
        {

        }

        public override void OnEnter()
        {
            base.OnEnter();
            machine.boss.Stop();
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            if (elapsedTime > 5.0f)
            {
                machine.ChangeState(new IdleState(machine)); //C# garbage collects unused states
            }
        }

        public override void OnExit()
        {
            base.OnExit();
        }
    }
}
