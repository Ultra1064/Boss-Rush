using UnityEngine;
namespace Victor
{
    public class State
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

        public virtual void OnExit()
        {

        }

        public virtual void OnUpdate()
        {

        }
    }
}

