using UnityEngine;
using System.Collections;

namespace Victor
{
    public class VictorBoss : MonoBehaviour
    {
        [SerializeField] float speed;
        [SerializeField] GameObject meleeWeapon;

        Navigator navigator;
        Transform form;
        Transform player;
        Rigidbody rb;

        StateMachine machine;

        Vector3 currentTargetNodePosition;
        public int pathNodeIndex = 0;
        Vector3 targetVelocity;
        public bool inMeleeRange = false;

        private void Awake()
        {
            machine = new StateMachine(this); //No components needed
            
            navigator = GetComponent<Navigator>();
            player = FindFirstObjectByType<PlayerLogic>().transform;
            rb = GetComponent<Rigidbody>();
            form = transform;
        }

        private void Start()
        {
            machine.ChangeState(new IdleState(machine)); //This starts the states!
        }

        void Update()
        {
            machine.OnUpdate();
        }

        private void FixedUpdate()
        {
            rb.linearVelocity = targetVelocity;
        }

        public bool AttemptBeginPursue()
        {
            //Debug.Log("attempting to pursue");

            if (AttemptMakePathToPlayer())
            {
                pathNodeIndex = 0;

                return true;
            }

            Debug.Log("failed attempt to pursue");

            return false;
        }

        public void UpdatePursue()
        {
            //Debug.Log("in pursue");

            currentTargetNodePosition = navigator.PathNodes[pathNodeIndex];

            //Debug.Log("current target position is " + currentTargetNodePosition + " at index " + pathNodeIndex);

            Vector3 dirToNode = (currentTargetNodePosition - form.position);//.normalized;
            dirToNode.y = 0;
            dirToNode.Normalize();

            form.forward = dirToNode;

            float distToNode = Vector3.Distance(currentTargetNodePosition, form.position);

            //Debug.Log("distance to node: " + distToNode);

            if (distToNode < 3f)
            {
                //Debug.Log("close to node");
                pathNodeIndex++;

                if (pathNodeIndex >= navigator.PathNodes.Count)
                {
                    pathNodeIndex = 0;
                    AttemptMakePathToPlayer();
                    return;
                }

            }

            targetVelocity = form.forward * speed;
            targetVelocity.y = rb.linearVelocity.y;
        }

        public void MeleeAttack()
        {
            var dirToPlayer = (player.transform.position - transform.position).normalized;
            dirToPlayer.y = 0;
            transform.forward = dirToPlayer;
            targetVelocity = Vector3.zero;
            StartCoroutine(HandleMelee());
        }

        IEnumerator HandleMelee()
        {
            //timeSinceLastMelee = 0;
            meleeWeapon.SetActive(true);
            meleeWeapon.GetComponent<Animator>().SetTrigger("swing");
            yield return new WaitForSeconds(0.25f);
            meleeWeapon.SetActive(false);
        }

        public void Death()
        {
            navigator.enabled = false;
            targetVelocity = Vector3.zero;
            GameManager.instance.GoToNextLevel();
            //state = EnemyStates.dead;
        }

        public bool AttemptMakePathToPlayer()
        {
            return (navigator.CalculatePathToPosition(player.position));
        }

        float DistanceToTarget(Transform target)
        {
            return Vector3.Distance(form.position, target.position);
        }

        public void SetInMeleeRange(bool inMeleeRange)
        {
            this.inMeleeRange = inMeleeRange;
        }

        public void FaceTarget(GameObject target)
        {
            var dirToTarget = (target.transform.position - transform.position).normalized;
            dirToTarget.y = 0;
            transform.forward = dirToTarget;
            targetVelocity = Vector3.zero;
        }
    }
}

