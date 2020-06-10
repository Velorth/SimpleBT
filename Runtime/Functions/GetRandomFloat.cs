using Random = UnityEngine.Random;

namespace SimpleProto.AI.BehaviourTrees
{
    /// <summary>
    /// Assigns output variable with random float value
    /// </summary>
    public class GetRandomFloat : BehaviourTreeNode
    {
        /// <summary>
        /// Output variable.
        /// </summary>
        public OutVariable<float> Output { get; set; }

        public InVariable<float> Min { get; set; }

        public InVariable<float> Max { get; set; }

        protected override NodeState OnRunning(object context)
        {
            Output.Set(Random.Range(Min, Max));
            return NodeState.Success;
        }
    }
}