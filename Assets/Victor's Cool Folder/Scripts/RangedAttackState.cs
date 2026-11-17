namespace Victor
{
    public class RangedAttackState : State
    {
        public RangedAttackState(StateMachine machine) : base(machine)
        {

        }

        public override void OnEnter()
        {
            base.OnEnter();
            //Activate particle effects for charg
            //Shoot
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
        }

        public override void OnExit()
        {
            base.OnExit();
        }
    }
}

