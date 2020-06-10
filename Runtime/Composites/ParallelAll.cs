namespace SimpleProto.AI.BehaviourTrees
{
    public class ParallelAll : Composite
    {
        protected override NodeState OnRunning(object context)
        {
            var isAnyRunning = false;
            for (var i = 0; i < Children.Count; ++i)
            {
                var childState = Children[i].Execute(context);
                if (childState == NodeState.Failure)
                    return NodeState.Failure;
                if (childState != NodeState.Success)
                    isAnyRunning = true;
            }

            return isAnyRunning ? NodeState.Running : NodeState.Success;
        }
    }
}
