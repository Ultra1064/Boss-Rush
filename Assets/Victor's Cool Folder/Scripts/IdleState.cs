namespace Victor
{
    public class IdleState : State
    {
        public IdleState(StateMachine machine) : base(machine)
        {

        }

        public override void OnEnter()
        {
            base.OnEnter();
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            
            if (elapsedTime > 2.0f && machine.boss.AttemptBeginPursue())
            {
                machine.ChangeState(new PursuitState(machine));
            }
        }

        public override void OnExit()
        {
            base.OnExit();
        }
    }
}
