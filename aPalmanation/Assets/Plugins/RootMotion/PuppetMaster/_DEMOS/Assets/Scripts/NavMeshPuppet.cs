using UnityEngine;
using System.Collections;
using RootMotion.Dynamics;

namespace RootMotion.Demos
{
    public class NavMeshPuppet : MonoBehaviour
    {
        public BehaviourPuppet puppet;
        public UnityEngine.AI.NavMeshAgent agent;
        public Transform target;
        public Animator animator;

        public float rotationSpeed = 20f;
        public float meleeRange = 1.2f;

        private void Start()
        {
           // target = PlayerHeadReference.instance.transform;
        }

        void Update()
        {
            // Keep the agent disabled while the puppet is unbalanced.
            agent.enabled = puppet.state == BehaviourPuppet.State.Puppet;

            // Update agent destination and Animator
            if (agent.enabled)
            {
                MoveTowards(target);// agent.SetDestination(target.position);

                if (IsInMeleeRangeOf(target))
                {
                    agent.updateRotation = true;
                    //RotateTowards(target);
                }
            }
        }

        private bool IsInMeleeRangeOf(Transform target)
        {
            float distance = Vector3.Distance(transform.position, target.position);
            return distance < meleeRange;
        }

        private void MoveTowards(Transform target)
        {
            agent.SetDestination(target.position);
            animator.SetFloat("Forward", agent.velocity.magnitude);
        }

        private void RotateTowards(Transform target)
        {
            Vector3 targetPos = Vector3.Project(target.position, Vector3.up);
            targetPos = new Vector3(targetPos.x, this.transform.position.y, targetPos.z);
            Vector3 direction = (targetPos - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
        }
    }
}
