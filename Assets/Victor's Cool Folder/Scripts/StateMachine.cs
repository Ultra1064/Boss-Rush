using UnityEngine;

namespace Victor
{
    public class StateMachine : MonoBehaviour
    {
        State currentState;
        GameObject enemy; //Change to boss script

        public StateMachine(GameObject enemy) //A Constructor in my Unity Project?!
        {
            this.enemy = enemy;
        }

        private void Update()
        {
            currentState.OnUpdate();
        }

        public void ChangeState(State newState)
        {
            if (currentState != null)
            {
                currentState.OnExit();
            }

            currentState = newState;

            currentState.OnEnter();
        }
    }
}

