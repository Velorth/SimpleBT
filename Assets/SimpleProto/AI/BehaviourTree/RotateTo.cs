using System;
using UnityEngine;

namespace SimpleProto.AI.BehaviourTrees
{
    /// <summary>
    /// Rotates character to the target.
    /// </summary>
    public class RotateTo : BaseBehaviourTreeNode
    {
        public InVariable<Vector3> Target { get; set; }
        
        protected override NodeState OnRunning(ExecutionContext context)
        {
            var sc = (SimpleContext) context;
            var transform = sc.Actor.transform;

            var look = Target - transform.position;
            look.y = 0;
            look.Normalize();
            transform.rotation = Quaternion.LookRotation(look);

            return NodeState.Success;
        }
    }
}