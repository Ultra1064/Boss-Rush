using UnityEngine;

namespace Victor
{
    public class Reflector : MonoBehaviour
    {
        [SerializeField] GameObject nextProjectile;
        /* If this is the Boss' Projectile (that it fires), nextProjectile should be the PlayerHomingProjectile
         * If this is the PlayerHomingProjectile, nextProjectile should be the BossHomingProjectile
         * If this is the BossHomingProjectile, nextProjectile should be the PlayerHomingProjectile
         * If this is the Boss' Reflect Empty Game Object, nextProjectile should be the BossHomingProjectile
         */

        public void Reflect() //Note: This doesn't actually reflect, it just creates a replacement projectile that fires the other way!
        {
            if (nextProjectile != null)
                Instantiate(nextProjectile, transform.position, Quaternion.Inverse(transform.rotation)); //Inverse flips it!
        }
    }
}

