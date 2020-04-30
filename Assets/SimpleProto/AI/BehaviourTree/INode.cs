using JetBrains.Annotations;

namespace SimpleProto.AI.BehaviourTrees
{
    public interface IBehaviourTreeNode
    {
        /// <summary>
        /// Gets current state of behaviour tree node
        /// </summary>
        NodeState State { get; }

        /// <summary>
        /// Resets node state to default
        /// </summary>
        /// <param name="context"></param>
        void Reset([NotNull] object context);

        /// <summary>
        /// Cancels node execution
        /// </summary>
        /// <param name="context"></param>
        void Cancel([NotNull] object context);

        /// <summary>
        /// Performs iteration of node execution
        /// </summary>
        /// <param name="context"></param>
        /// <returns>New state of the node</returns>
        NodeState Execute([NotNull] object context);
    }
}