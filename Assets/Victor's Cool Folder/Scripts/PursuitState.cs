namespace Victor
{
    public class PursuitState : State
    {
        public PursuitState(StateMachine machine) : base(machine)
        {

        }

        public override void OnEnter()
        {
            base.OnEnter();
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            machine.boss.UpdatePursue();

            if (machine.boss.inMeleeRange)
            {
                // do melee attack
                machine.ChangeState(new MeleeState(machine));
                return;
            }

            if (elapsedTime > 1) // rebuild path every half second
            {
                machine.boss.pathNodeIndex = 1;
                machine.boss.AttemptMakePathToPlayer();
            }
        }

        public override void OnExit()
        {
            base.OnExit();
            machine.boss.Stop();
        }
    }
}
