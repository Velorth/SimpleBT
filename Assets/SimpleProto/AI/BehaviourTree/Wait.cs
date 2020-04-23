using UnityEngine;

namespace SimpleProto.AI.BehaviourTrees
{
    public sealed class Wait : BaseBehaviourTreeNode
    {
        private float _endTime;

        /// <summary>
        /// Gets or sets waiting time
        /// </summary>
        public InVariable<float> Time { get; set; }

        protected override void OnReset()
        {
            _endTime = -1;
        }

        protected override NodeState OnStart(ExecutionContext context)
        {
            _endTime = UnityEngine.Time.time + Time;
            return NodeState.Running;
        }

        protected override NodeState OnRunning(ExecutionContext context)
        {
            return UnityEngine.Time.time < _endTime ? NodeState.Running : NodeState.Success;
        }
    }
}