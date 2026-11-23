using UnityEngine;
namespace Victor
{
    public abstract class State
    {
        protected StateMachine machine;
        public float elapsedTime;

        public State(StateMachine machine)
        {
            this.machine = machine;
        }

        public virtual void OnEnter()
        {

        }

        public virtual void OnUpdate()
        {
            elapsedTime += Time.deltaTime;

            bool? projectileCheck = machine.boss.CheckForProjectile(); //Want to be able to reflect from (almost) any state
            if (projectileCheck != null)
            {
                if ((bool)projectileCheck)
                    return;
            }
        }

        public virtual void OnExit()
        {

        }
    }
}

