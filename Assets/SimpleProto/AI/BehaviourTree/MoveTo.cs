using System;
using UnityEngine;

namespace SimpleProto.AI.BehaviourTrees
{
    public sealed class MoveTo : BaseBehaviourTreeNode
    {
        public InVariable<Vector3> Target { get; set; }

        public InVariable<float> Speed { get; set; } = 5f;

        protected override NodeState OnRunning(ExecutionContext context)
        {
            var sc = (SimpleContext)context;
            var transform = sc.Actor.transform;

            transform.position = Vector3.MoveTowards(transform.position, Target, Speed * Time.deltaTime);

            var distance = Vector3.Distance(transform.position, Target);

            return distance < 0.01f
                ? NodeState.Success
                : NodeState.Running;
        }
    }
}