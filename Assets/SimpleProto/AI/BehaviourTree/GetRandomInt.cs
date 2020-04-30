using Random = UnityEngine.Random;

namespace SimpleProto.AI.BehaviourTrees
{
    /// <summary>
    /// Assigns output variable with random integer value.
    /// </summary>
    public class GetRandomInt : BaseBehaviourTreeNode
    {
        /// <summary>
        /// Output variable.
        /// </summary>
        public OutVariable<int> Output { get; set; }

        public InVariable<int> Min { get; set; }

        public InVariable<int> Max { get; set; }

        protected override NodeState OnRunning(object context)
        {
            Output.Set(Random.Range(Min, Max));
            return NodeState.Success;
        }
    }
}