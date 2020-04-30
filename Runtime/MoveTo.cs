using UnityEngine;

namespace SimpleProto.AI.BehaviourTrees
{
    public sealed class MoveTo : BehaviourTreeNode<GameObject>
    {
        public InVariable<Vector3> Target { get; set; }

        public InVariable<float> Speed { get; set; } = 5f;

        protected override NodeState OnRunning(GameObject actor)
        {
            var transform = actor.transform;
            var position = transform.position;

            position = Vector3.MoveTowards(position, Target, Speed * Time.deltaTime);

            transform.position = position;
            var distance = Vector3.Distance(position, Target);

            return distance < 0.01f
                ? NodeState.Success
                : NodeState.Running;
        }
    }
}