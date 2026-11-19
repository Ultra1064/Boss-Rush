using UnityEngine;

namespace Victor
{
    public class BossHomingProjectile : MonoBehaviour
    {
        [SerializeField] float speed = 30;
        Rigidbody rigidBody;
        GameObject target;

        void Start()
        {
            rigidBody = GetComponent<Rigidbody>();
            target = FindAnyObjectByType<PlayerLogic>().gameObject;
        }

        private void Update() //This homes in on the target
        {
            if (target == null)
                return;

            Vector3 direction = (target.transform.position - transform.position).normalized; //Target Vector minus this Vector equals the distance between the two. (Vectors also point, which matters here)

            rigidBody.linearVelocity = direction * speed;
            transform.forward = direction;
        }

        public void DestroyProjectile()
        {
            Destroy(gameObject);
        }
    }
}

