using UnityEngine;

namespace Victor
{
    public class ReadyReflectState : State
    {
        int reflectCounter;
        int maxReflects;
        public ReadyReflectState(StateMachine machine, int maxReflects) : base(machine)
        {
            reflectCounter = 0;
            this.maxReflects = maxReflects;
        }

        public override void OnEnter()
        {
            base.OnEnter();
        }

        public override void OnUpdate()
        {
            if (machine.boss.inMeleeRange && reflectCounter <= maxReflects)
            {
                machine.boss.MeleeAttack();
                reflectCounter++;
                if (machine.boss.playerShot.GetComponent<PlayerHomingProjectile>())
                {
                    machine.boss.playerShot.GetComponent<Reflector>().Reflect();
                    
                }
                else
                    machine.boss.GetComponentInChildren<Reflector>().Reflect();
                //machine.boss.playerShot.GetComponent<Projectile>().DestroyProjectile(); //Pretty sure the projectile calls this already
            }
        }

        public override void OnExit()
        {
            base.OnExit();
        }
    }
}