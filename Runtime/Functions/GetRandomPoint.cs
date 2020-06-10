using UnityEngine;

namespace SimpleProto.AI.BehaviourTrees
{
    public class GetRandomPoint : BehaviourTreeNode
    {
        public OutVariable<Vector3> Output { get; set; }
        public InVariable<float> Radius { get; set; } = 5f;
        public InVariable<Vector3> Center { get; set; } = Vector3.zero;

        protected override NodeState OnStart(object context)
        {
            var p = Random.insideUnitCircle * Radius;
            Output.Set(Center + new Vector3(p.x, 0, p.y));

            return NodeState.Success;
        }
    }
}