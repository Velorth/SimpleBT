using System;
using UnityEngine;

namespace SimpleProto.AI.BehaviourTrees
{
    /// <summary>
    /// Rotates character to the target.
    /// </summary>
    public class RotateTo : BehaviourTreeNode<GameObject>
    {
        public InVariable<Vector3> Target { get; set; }
        
        protected override NodeState OnRunning(GameObject actor)
        {
            var transform = actor.transform;

            var look = Target - transform.position;
            look.y = 0;
            look.Normalize();
            transform.rotation = Quaternion.LookRotation(look);

            return NodeState.Success;
        }
    }
}