namespace SimpleProto.AI.BehaviourTrees
{
    /// <summary>
    /// Sequience task
    /// </summary>
    /// <remarks>
    /// Tasks in the sequence are executed one by one.
    /// If one of the task fails the whole sequence will fail.
    /// </remarks>
    public class Sequence : Composite
    {
        protected override NodeState OnRunning(object context)
        {
            for (var i = 0; i < Children.Count; ++i)
            {
                var child = Children[i];
                var childState = child.Execute(context);
                if (childState == NodeState.Failure)
                    return NodeState.Failure;
                if (childState == NodeState.Running)
                    return NodeState.Running;
            }

            return NodeState.Success;
        }
    }
}