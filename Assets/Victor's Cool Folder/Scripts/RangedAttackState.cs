using UnityEngine;

namespace Victor
{
    public class RangedAttackState : State
    {
        public RangedAttackState(StateMachine machine) : base(machine)
        {

        }

        public override void OnEnter()
        {
            //Activate particle effects for charg
            //Shoot
        }

        //No OnUpdate needed

        //No OnExit needed (I don't think)
    }
}

