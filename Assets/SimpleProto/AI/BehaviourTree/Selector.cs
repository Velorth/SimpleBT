using System;

namespace SimpleProto.AI.BehaviourTrees
{
    /// <summary>
    /// Selector task will be completed when any child is completed
    /// </summary>
    public class Selector : Composite
    {
        protected override NodeState OnRunning(ExecutionContext context)
        {
            for (var i = 0; i < Children.Count; ++i)
            {
                var child = Children[i];
                var childState = child.Execute(context);
                if (childState == NodeState.Success)
                    return NodeState.Success;
                if (childState == NodeState.Running)
                    return NodeState.Running;
            }

            return NodeState.Failure;
        }
    }
}
