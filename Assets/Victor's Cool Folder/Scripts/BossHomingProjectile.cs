using UnityEngine;

namespace Victor
{
    public class BossHomingProjectile : Projectile
    {
        [SerializeField] float sspeed = 30;
        Rigidbody rrigidBody;
        GameObject target;

        void Start()
        {
            rrigidBody = GetComponent<Rigidbody>();
            target = FindAnyObjectByType<PlayerLogic>().gameObject;
        }

        private void Update() //This homes in on the target
        {
            if (target == null)
                return;

            Vector3 direction = (target.transform.position - transform.position).normalized; //Target Vector minus this Vector equals the distance between the two. (Vectors also point, which matters here)

            rrigidBody.linearVelocity = direction * sspeed;
            transform.forward = direction;
        }
    }
}

