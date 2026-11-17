namespace Victor
{
    public class MeleeState : State
    {
        public MeleeState(StateMachine machine) : base(machine)
        {

        }

        public override void OnEnter()
        {
            base.OnEnter();
            machine.boss.MeleeAttack();
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            if (elapsedTime > 2.0f)
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
