namespace SimpleProto.AI.BehaviourTrees
{
    public sealed class Wait : BehaviourTreeNode
    {
        private float _endTime;

        /// <summary>
        /// Gets or sets waiting time
        /// </summary>
        public InVariable<float> Time { get; set; }

        protected override void OnReset(object context)
        {
            _endTime = -1;
        }

        protected override NodeState OnStart(object context)
        {
            _endTime = UnityEngine.Time.time + Time;
            return NodeState.Running;
        }

        protected override NodeState OnRunning(object context)
        {
            return UnityEngine.Time.time < _endTime ? NodeState.Running : NodeState.Success;
        }
    }
}