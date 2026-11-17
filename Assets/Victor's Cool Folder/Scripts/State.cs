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
        }

        public virtual void OnExit()
        {

        }
    }
}

