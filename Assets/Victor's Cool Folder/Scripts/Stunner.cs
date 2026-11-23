using UnityEngine;

namespace Victor
{
    public class Stunner : MonoBehaviour
    {
        public void StunBoss()
        {
            VictorBoss boss = FindAnyObjectByType<VictorBoss>();
            boss.Stun();
        }
    }
}

